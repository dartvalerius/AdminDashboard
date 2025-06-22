using System.Net;
using System.Text.Json;
using AD.Application.Exceptions;

namespace AD.WebApi.Middleware;

/// <summary>
/// Обработчик возникших исключений при обработке запроса
/// </summary>
public class CustomExceptionHandlerMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandlerExceptionAsync(context, e);
        }
    }

    private Task HandlerExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;

        switch (exception)
        {
            case AuthenticationException authenticationException:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(authenticationException.Message);
                break;
            case NotFoundException notFoundException:
                code = HttpStatusCode.NotFound;
                result = JsonSerializer.Serialize(notFoundException.Message);
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        if (string.IsNullOrEmpty(result))
            result = JsonSerializer.Serialize(exception.Message);

        return context.Response.WriteAsync(result);
    }
}