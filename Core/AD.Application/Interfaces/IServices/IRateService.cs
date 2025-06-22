using AD.Application.DTO.RateDTO;
using AD.Application.ViewModels.Rate;

namespace AD.Application.Interfaces.IServices;

/// <summary>
/// Сервис для работы с курсами
/// </summary>
public interface IRateService
{
    /// <summary>
    /// Получить текущий курс
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Модель отображения текущего курса</returns>
    Task<RateVm> GetCurrentAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Создать новый курс
    /// </summary>
    /// <param name="dto">Данные для создания курса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateAsync(CreateRateDto dto, CancellationToken cancellationToken = default);
}