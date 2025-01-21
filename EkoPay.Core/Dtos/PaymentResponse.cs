namespace EkoPay.Core.Dtos;

public class PaymentResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string TransactionId { get; set; }

    public string Processor { get; set; }
}