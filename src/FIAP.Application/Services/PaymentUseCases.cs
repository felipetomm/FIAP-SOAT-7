
using FIAP.Application.InputModels;
using FIAP.Application.Interfaces;
using FIAP.Application.OutputModels;
using FIAP.Domain.Entities.Store;
using FIAP.Domain.Interfaces.Repositories;
using FIAP.Infrastructure.CrossCutting.Interfaces;

namespace FIAP.Application.Services;

public class PaymentUseCases : IPaymentUseCases
{
    private readonly IPaymentsRepository _repository;
    private readonly IUnitOfWork _uow;

    public PaymentUseCases(
        IPaymentsRepository repository,
        IUnitOfWork uow
    )
    {
        _repository = repository;
        _uow = uow;
    }

    public async Task<CheckPaymentOutputModel> CheckPaymentAsync(long id)
    {
        var payment = await _repository.FindByIdAsync(id);

        if (payment == null)
            throw new ArgumentException("Payment not found");

        return new CheckPaymentOutputModel
        {
            Amount = payment.Amount,
            Gateway = new CheckPaymentOutputModel.GatewayModel(payment.Gateway),
            Status = new CheckPaymentOutputModel.StatusModel(payment.Status),
        };
    }

    public async Task<Payments> SyncPaymentByGatewayAsync(SyncPaymentByGatewayModel model)
    {
        var payment = await _repository.FindByExternalTransactionIdAsync(model.ExternalTransactionId);

        if (payment == default)
            throw new ArgumentException("Payment not found");

        payment.ApprovePayment(
            model.ExternalTransactionId,
            model.Gateway
        );

        var result = await _repository.UpdateAsync(payment);

        await _uow.CommitAsync();

        return result;
    }

}