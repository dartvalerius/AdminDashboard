using AD.Application.Interfaces.IServices;
using AD.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AD.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IRateService, RateService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IAccountService, AccountService>();

        return services;
    }
}