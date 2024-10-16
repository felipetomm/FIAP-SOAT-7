using FIAP.Domain.Entities.Base;
using FIAP.Domain.Entities.Enums;
using FIAP.Infrastructure.CrossCutting.Extensions;

namespace FIAP.Domain.Entities.Store;

public class Payments : EntityBaseSoft<long>
{
    public PaymentStatus Status { get; private set; }
    public string ExternalTransactionId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentGateway Gateway { get; set; }

    protected Payments() { }

    public Payments(
        PaymentStatus status,
        PaymentGateway gateway,
        decimal amount,
        string externalTransactionId
    )
    {
        var validationResult = Validate(
            status: status,
            gateway: gateway,
            amount: amount,
            externalTransactionId: externalTransactionId
        );

        if (validationResult.IsInvalid())
            throw new ArgumentException(validationResult.GetErrorsMessage());

        Status = status;
        Gateway = gateway;
        Amount = amount;
        ExternalTransactionId = externalTransactionId;
    }

    public void ApprovePayment(
        string externalTransactionId,
        PaymentGateway gateway
    )
    {
        var validationResult = ValidateApprovedPayment(
            externalTransactionId,
            gateway
        );

        if (validationResult.IsInvalid())
            throw new ArgumentException(validationResult.GetErrorsMessage());

        ExternalTransactionId = externalTransactionId;
        Status = PaymentStatus.APPROVED;
    }

    private DomainValidationResult Validate(
        PaymentStatus status,
        PaymentGateway gateway,
        decimal amount,
        string externalTransactionId
    )
    {
        var validationResult = new DomainValidationResult();

        if (amount < 0)
            validationResult.AddError("Amount value cant be less than $0.00");

        if (status == default)
            validationResult.AddError("Payment Status is mandatory");

        if (gateway == default)
            validationResult.AddError("Payment Gateway is mandatory");

        if (externalTransactionId.IsEmpty())
            validationResult.AddError("External Transaction Identification is mandatory to approve the payment");

        #region APENAS_PARA_PERIODO_DE_TESTE

        var availableGateways = new List<PaymentGateway>
        {
            PaymentGateway.FAKE_GATEWAY
        };
        if (!availableGateways.Contains(gateway))
            validationResult.AddError("During test phase, some payment gateways aren't available");

        #endregion 

        return validationResult;
    }

    private DomainValidationResult ValidateApprovedPayment(
        string externalTransactionId,
        PaymentGateway gateway
    )
    {
        var validationResult = new DomainValidationResult();

        if (Status != PaymentStatus.PENDING)
            validationResult.AddError($"Status need to be {Status.ToDescription()}");

        if (externalTransactionId.IsEmpty())
            validationResult.AddError("External Transaction Identification is mandatory to approve the payment");

        if (gateway != Gateway)
            validationResult.AddError("Can't be change Gateway from Payment");

        return validationResult;
    }
}