using EkoPay.Core.Dtos;

namespace EkoPay.Core.Interfaces;

public interface IPaymentProcessor
{
    Task<PaymentResponse> ProcessPayment(PaymentRequest paymentRequest);

}