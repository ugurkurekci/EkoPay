using EkoPay.Core.Dtos;
using EkoPay.Core.Interfaces;

namespace Integrations.Masterpass;

public class MasterpassPaymentProcessor : IPaymentProcessor
{
    public async Task<PaymentResponse> ProcessPayment(PaymentRequest paymentRequest)
    {

        return new PaymentResponse
        {
            Success = true,
            Message = "Ödeme başarılı",
            TransactionId = "123456",
            Processor = "Masterpass"
        };
    }
}