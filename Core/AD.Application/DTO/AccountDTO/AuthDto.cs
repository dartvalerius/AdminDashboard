namespace AD.Application.DTO.AccountDTO;

/// <summary>
/// Данные для аутентификации
/// </summary>
public record AuthDto
{
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public required string Password { get; set; }
}