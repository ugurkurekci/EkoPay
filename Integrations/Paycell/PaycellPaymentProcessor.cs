using EkoPay.Core.Dtos;
using EkoPay.Core.Interfaces;

namespace Integrations.Paycell;
public class PaycellPaymentProcessor : IPaymentProcessor
{
    public async Task<PaymentResponse> ProcessPayment(PaymentRequest paymentRequest)
    {

        return new PaymentResponse
        {
            Success = true,
            Message = "Ödeme başarılı",
            TransactionId = Guid.NewGuid().ToString(),
            Processor = "Paycell"
        };
    }
}