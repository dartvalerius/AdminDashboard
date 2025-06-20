using AD.Application.Interfaces;
using AD.Persistence.Data;
using AD.Persistence.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AD.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ADDbContext>(options => options.UseSqlite(configuration["DbConnection"]));
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}