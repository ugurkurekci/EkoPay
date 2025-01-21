using EkoPay.Core;
using EkoPay.Core.Interfaces;
using EkoPay.Service.Services;
using Integrations.Masterpass;
using Integrations.Paycell;
using Integrations.PayPal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Integrations;
public static class DependencyResolver
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<PayPalPaymentProcessor>();
        services.AddSingleton<MasterpassPaymentProcessor>();
        services.AddSingleton<PaycellPaymentProcessor>();

        services.AddSingleton<IPaymentProcessor>(serviceProvider =>
        {
            var paymentSettings = serviceProvider.GetRequiredService<IOptions<PaymentSettings>>().Value;
            if (string.IsNullOrEmpty(paymentSettings?.PaymentMethod))
            {
                throw new InvalidOperationException("PaymentSettings.PaymentMethod is not configured.");
            }

            return paymentSettings.PaymentMethod switch
            {
                "PayPal" => serviceProvider.GetRequiredService<PayPalPaymentProcessor>(),
                "Masterpass" => serviceProvider.GetRequiredService<MasterpassPaymentProcessor>(),
                "Paycell" => serviceProvider.GetRequiredService<PaycellPaymentProcessor>(),
                _ => throw new InvalidOperationException($"Unsupported payment method: {paymentSettings.PaymentMethod}.")
            };
        });

        // IPaymentService kaydı
        services.AddSingleton<IPaymentService, PaymentService>();
    }
}
