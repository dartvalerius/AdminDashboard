using AD.Application;
using AD.Persistence;
using AD.Persistence.Data;
using AD.WebApi.ApiEndpoints;
using AD.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string corsPolicyName = "AllowAll";

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName,
        corsPolicy => corsPolicy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ADDbContext>();

        context.Database.Migrate();

        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Произошла ошибка при заполнении базы данных.");
    }
}

app.UseMiddleware<CustomExceptionHandlerMiddleware>();

app.UseCors(corsPolicyName);

app.MapRateEndpoints();
app.MapPaymentEndpoints();
app.MapClientEndpoints();
app.MapAccountEndpoints();

app.Run();