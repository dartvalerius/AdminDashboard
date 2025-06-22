using AD.Application.DTO.AccountDTO;
using AD.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AD.WebApi.ApiEndpoints;

/// <summary>
/// Конечные точки для работы с учётными записями
/// </summary>
public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this WebApplication app)
    {
        app.MapPost("/auth/login", AuthenticateAsync);
    }

    private static async Task<IResult> AuthenticateAsync([FromBody] AuthDto dto, HttpContext context,
        IAccountService accountService) =>
        Results.Ok(await accountService.AuthenticateAsync(dto, context.RequestAborted));
}