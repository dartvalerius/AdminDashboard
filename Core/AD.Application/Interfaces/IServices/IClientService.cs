using AD.Application.DTO.ClientDTO;
using AD.Application.Exceptions;
using AD.Application.ViewModels.Client;

namespace AD.Application.Interfaces.IServices;

/// <summary>
/// Сервис для работы с клиентами
/// </summary>
public interface IClientService
{
    /// <summary>
    /// Создать клиента
    /// </summary>
    /// <param name="dto">Данные для создания клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор клиента</returns>
    Task<string> CreateAsync(CreateClientDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить данные клиента
    /// </summary>
    /// <param name="dto">Данные для обновления данных клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <exception cref="NotFoundException">Клиент не найден</exception>
    Task UpdateAsync(UpdateClientDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить клиента
    /// </summary>
    /// <param name="id">Идентификатор клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <exception cref="NotFoundException">Клиент не найден</exception>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить список клиентов
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Модель данных списка клиентов</returns>
    Task<ClientListVm> ListAsync(CancellationToken cancellationToken = default);
}