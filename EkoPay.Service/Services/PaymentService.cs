using EkoPay.Core.Dtos;
using EkoPay.Core.Interfaces;

namespace EkoPay.Service.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public PaymentService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public async Task<PaymentResponse> ProcessPayment(PaymentRequest paymentRequest)
    {
        return await _paymentProcessor.ProcessPayment(paymentRequest);
    }
}