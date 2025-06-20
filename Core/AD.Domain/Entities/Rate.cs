namespace AD.Domain.Entities;

/// <summary>
/// Курс
/// </summary>
public class Rate
{
    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Дата установки курса
    /// </summary>
    public DateTime DateSet { get; set; }

    /// <summary>
    /// Текущий курс
    /// </summary>
    public decimal CurrentRate { get; set; }

    /// <summary>
    /// Список платежей
    /// </summary>
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}