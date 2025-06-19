namespace AD.Domain.Entities;

/// <summary>
/// Учётная запись
/// </summary>
public class Account
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
    /// Хэш пароля
    /// </summary>
    public required string PasswordHash { get; set; }

    /// <summary>
    /// Соль шифрования пароля
    /// </summary>
    public required string Salt { get; set; }

    /// <summary>
    /// Роль
    /// </summary>
    public required string Role { get; set; }

    /// <summary>
    /// Профиль пользователя
    /// </summary>
    public required UserProfile UserProfile { get; set; }
}