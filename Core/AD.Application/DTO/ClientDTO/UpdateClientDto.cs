namespace AD.Application.DTO.ClientDTO;

/// <summary>
/// Данные для изменения данных пользователя
/// </summary>
public record UpdateClientDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; set; }
}