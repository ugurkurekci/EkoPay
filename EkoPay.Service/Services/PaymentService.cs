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

        PaymentResponse processPaymentResult = await _paymentProcessor.ProcessPayment(paymentRequest);
        if (!processPaymentResult.Success)
        {
            return new PaymentResponse
            {
                Success = false,
                Message = processPaymentResult.Message
            };
        }

        return new PaymentResponse
        {
            Success = true,
            Message = processPaymentResult.Message,
            TransactionId = processPaymentResult.TransactionId,
            Processor = processPaymentResult.Processor
        };
    }
}