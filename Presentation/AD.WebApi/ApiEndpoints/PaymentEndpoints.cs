using AD.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AD.WebApi.ApiEndpoints;

/// <summary>
/// Конечные точки для работы с платежами
/// </summary>
public static class PaymentEndpoints
{
    public static RouteGroupBuilder MapPaymentEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/payments");

        group.MapGet("/", ListAsync);

        return group;
    }

    private static async Task<IResult> ListAsync([FromQuery] int take, HttpContext context,
        IPaymentService paymentService) => Results.Ok(await paymentService.ListAsync(take, context.RequestAborted));
}