using AD.Application.Interfaces.IServices;
using AD.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AD.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPaymentService, PaymentService>();

        return services;
    }
}