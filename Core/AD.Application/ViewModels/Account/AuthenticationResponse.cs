namespace AD.Application.ViewModels.Account;

/// <summary>
/// Ответ после аутентификации
/// </summary>
public class AuthenticationResponse
{
    /// <summary>
    /// Токен аутентификации
    /// </summary>
    public string Token { get; set; } = string .Empty;

    /// <summary>
    /// Токен обновления
    /// </summary>
    public string RefreshToken { get; set; } = string .Empty;
}