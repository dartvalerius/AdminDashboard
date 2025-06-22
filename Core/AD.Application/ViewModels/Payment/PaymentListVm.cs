namespace AD.Application.ViewModels.Payment;

/// <summary>
/// Модель отображения списка платежей
/// </summary>
public class PaymentListVm
{
    public IList<PaymentListItemVm> Payments { get; set; } = [];

    /// <summary>
    /// Общее количество платежей
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Количество полученных платежей
    /// </summary>
    public int Take { get; set; }
}