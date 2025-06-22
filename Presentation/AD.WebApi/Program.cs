using AD.Application;
using AD.Persistence;
using AD.Persistence.Data;
using AD.WebApi.ApiEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

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

app.MapRateEndpoints();
app.MapPaymentEndpoints();
app.MapClientEndpoints();

app.Run();