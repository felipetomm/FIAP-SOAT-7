using FIAP.Domain.Dtos.ExternalServices;

namespace FIAP.Domain.Interfaces.ExternalServices;

public interface IPaymentGatewayService
{
    Task<CreatePaymentResult> CreatePaymentAsync(CreatePaymentDto request);

    Task<CheckPaymentResult> CheckPaymentAsync(string paymentId);
}