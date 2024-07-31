using FIAP.Domain.Entities.Enums;

namespace FIAP.Application.InputModels;
public class SyncPaymentByGatewayModel
{
    public string ExternalTransactionId { get; set; }
    public PaymentStatus Status { get; set; }
    public PaymentGateway Gateway { get; set; }
}