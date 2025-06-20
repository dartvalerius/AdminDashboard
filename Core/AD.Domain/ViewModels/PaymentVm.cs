namespace AD.Domain.ViewModels;

/// <summary>
/// Модель отображения платежа
/// </summary>
public class PaymentVm
{
    /// <summary>
    /// Дата платежа
    /// </summary>
    public string DateTime { get; set; } = string.Empty;

    /// <summary>
    /// Сумма платежа
    /// </summary>
    public string Amount { get; set; } = string.Empty;

    /// <summary>
    /// Курс
    /// </summary>
    public string Rate { get; set; } = string.Empty;

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Адрес электронной почты пользователя
    /// </summary>
    public string UserEmail { get; set; } = string.Empty;
}