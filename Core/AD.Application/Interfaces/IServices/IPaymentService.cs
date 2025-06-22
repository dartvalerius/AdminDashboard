using AD.Application.ViewModels.Payment;

namespace AD.Application.Interfaces.IServices;

/// <summary>
/// Сервис для работы с платежами
/// </summary>
public interface IPaymentService
{
    /// <summary>
    /// Получить список платежей
    /// </summary>
    /// <param name="takeLast">Количество получаемых последних платежей</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список моделей отображения последних платежей</returns>
    Task<IList<PaymentVm>> ListAsync(int takeLast = 0, CancellationToken cancellationToken = default);
}