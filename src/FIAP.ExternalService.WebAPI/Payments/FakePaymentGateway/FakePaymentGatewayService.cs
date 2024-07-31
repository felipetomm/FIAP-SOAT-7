
using FIAP.Domain.Dtos.ExternalServices;
using FIAP.Domain.Interfaces.ExternalServices;

namespace FIAP.ExternalService.WebAPI.Payments.FakePaymentGateway;

public class FakePaymentGatewayService : IFakePaymentGatewayService
{
    public Task<CheckPaymentResult> CheckPaymentAsync(string paymentId)
    {
        return Task.FromResult(new CheckPaymentResult
        {
            Id = paymentId,
            Message = "Payment approved",
            Status = "APPROVED"
        });
    }

    public Task<CreatePaymentResult> CreatePaymentAsync(CreatePaymentDto request)
    {
        return Task.FromResult(
            new CreatePaymentResult
            {
                Amount = request.Amount,
                CreatedAt = DateTime.Now,
                ExternalTransactionId = Guid.NewGuid().ToString(),
                PaymentId = request.TransactionId.ToString(),
                QrCode = "00020126330014BR.GOV.BCB.PIX011112555396071520400005303986540510.005802BR5905TESTE6005TESTE62090505TESTE6304AA73",
                Status = "PENDING",
                PaymentMethod = request.PaymentMethod,
            }
        );
    }
}