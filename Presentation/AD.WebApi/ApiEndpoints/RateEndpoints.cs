using AD.Application.DTO.RateDTO;
using AD.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AD.WebApi.ApiEndpoints;

/// <summary>
/// Конечные точки для работы с курсами
/// </summary>
public static class RateEndpoints
{
    public static RouteGroupBuilder MapRateEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/rate");

        group.MapGet("/", GetCurrentAsync);
        group.MapPost("/", CreateAsync);

        return group;
    }

    private static async Task<IResult> GetCurrentAsync(HttpContext context, IRateService rateService) =>
        Results.Ok(await rateService.GetCurrentAsync(context.RequestAborted));

    private static async Task<IResult> CreateAsync([FromBody] CreateRateDto dto, HttpContext context, IRateService rateService)
    {
        await rateService.CreateAsync(dto, context.RequestAborted);
        return Results.Created("/rate", "");
    }
}