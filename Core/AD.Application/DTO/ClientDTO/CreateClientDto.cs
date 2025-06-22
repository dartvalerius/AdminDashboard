namespace AD.Application.DTO.ClientDTO;

/// <summary>
/// Данные для создания клиента
/// </summary>
public record CreateClientDto
{
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public required string Password { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; set; }
}