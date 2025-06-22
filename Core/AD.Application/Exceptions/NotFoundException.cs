namespace AD.Application.Exceptions;

/// <summary>
/// Исключение о невозможности найти объект
/// </summary>
public class NotFoundException : Exception
{
    public NotFoundException()
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}