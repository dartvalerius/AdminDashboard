namespace AD.Domain.Entities;

/// <summary>
/// Платежи
/// </summary>
public class Payment
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Дата платежа
    /// </summary>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// Сумма платежа
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Идентификатор профиля пользователя
    /// </summary>
    public Guid UserProfileId { get; set; }

    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid RateId { get; set; }

    /// <summary>
    /// Профиль пользователя
    /// </summary>
    public required UserProfile UserProfile { get; set; }

    /// <summary>
    /// Курс
    /// </summary>
    public required Rate Rate { get; set; }
}