using EkoPay.Api.Controllers;
using EkoPay.Core.Dtos;
using Integrations.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class PaymentController : BaseController
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest paymentRequest)
    {
        var response = await _paymentService.ProcessPayment(paymentRequest);
        return Ok(response);
    }
}