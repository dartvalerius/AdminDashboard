using AD.Application.DTO.AccountDTO;
using AD.Application.Exceptions;
using AD.Application.ViewModels.Account;

namespace AD.Application.Interfaces.IServices;

/// <summary>
/// Сервис для работы с учётными записями
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Аутентификация
    /// </summary>
    /// <param name="dto">Данные для аутентификации</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Ответ на аутентификацию</returns>
    /// <exception cref="AuthenticationException">Исключение аутентификации</exception>
    Task<AuthenticationResponse> AuthenticateAsync(AuthDto dto, CancellationToken cancellationToken = default);
}