namespace FIAP.Domain.Dtos.ExternalServices;

public class CreatePaymentResult
{
    public string PaymentId { get; set; }
    public string ExternalTransactionId { get; set; }
    public string Status { get; set; }
    public string QrCode { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public string PaymentMethod { get; set; }
}