namespace AD.Application.ViewModels.Rate;

/// <summary>
/// Модель отображения курса
/// </summary>
public class RateVm
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Дата установки курса
    /// </summary>
    public string DateSet { get; set; } = string.Empty;

    /// <summary>
    /// Текущий курс
    /// </summary>
    public string CurrentRate { get; set; } = string.Empty;
}