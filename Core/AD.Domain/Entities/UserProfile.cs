namespace AD.Domain.Entities;

/// <summary>
/// Профиль пользователя
/// </summary>
public class UserProfile
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Текущий баланс
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    /// Учётная запись
    /// </summary>
    public required Account Account { get; set; }

    /// <summary>
    /// Список платежей
    /// </summary>
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}