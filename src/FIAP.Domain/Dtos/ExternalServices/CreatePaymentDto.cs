namespace FIAP.Domain.Dtos.ExternalServices;

public class CreatePaymentDto
{
    public decimal Amount { get; set; }
    public Guid TransactionId { get; set; }
    public string PaymentMethod { get; set; }
}