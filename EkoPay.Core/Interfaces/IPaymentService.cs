using EkoPay.Core.Dtos;

namespace EkoPay.Core.Interfaces;

public interface IPaymentService
{
    Task<PaymentResponse> ProcessPayment(PaymentRequest paymentRequest);

}