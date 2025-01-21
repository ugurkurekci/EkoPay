namespace EkoPay.Core.Dtos;

public class PaymentRequest
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string PaymentMethod { get; set; }
    public string CustomerId { get; set; }
}