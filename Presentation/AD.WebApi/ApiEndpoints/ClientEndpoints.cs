using AD.Application.DTO.ClientDTO;
using AD.Application.Interfaces.IServices;

namespace AD.WebApi.ApiEndpoints;

/// <summary>
/// Конечные точки для работы с клиентами
/// </summary>
public static class ClientEndpoints
{
    public static RouteGroupBuilder MapClientEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/clients");

        group.MapPost("/", CreateAsync);
        group.MapPut("/", UpdateAsync);
        group.MapDelete("/{id:guid}", DeleteAsync);
        group.MapGet("/", ListAsync);

        return group;
    }

    private static async Task<IResult> CreateAsync(CreateClientDto dto, HttpContext context, IClientService clientService)
    {
        var id = await clientService.CreateAsync(dto, context.RequestAborted);
        return Results.Created("", id);
    }

    private static async Task<IResult> UpdateAsync(UpdateClientDto dto, HttpContext context, IClientService clientService)
    {
        await clientService.UpdateAsync(dto, context.RequestAborted);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteAsync(Guid id, HttpContext context, IClientService clientService)
    {
        await clientService.DeleteAsync(id, context.RequestAborted);
        return Results.Ok();
    }

    private static async Task<IResult> ListAsync(HttpContext context, IClientService clientService)
    {
        return Results.Ok(await clientService.ListAsync(context.RequestAborted));
    }
}