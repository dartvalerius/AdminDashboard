namespace AD.Application.Interfaces;

/// <summary>
/// Интерфейс хеширования пароля
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Проверить правильность введённого пароля
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <param name="hash">Хэш пароля</param>
    /// <param name="salt">Соль шифрования</param>
    /// <returns><c>true</c> - пароль верный</returns>
    bool IsValid(string password, string hash, string salt);

    /// <summary>
    /// Получить хэш пароля
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <param name="salt">Соль шифрования</param>
    /// <returns>Хэш пароля</returns>
    string Hash(string password, string salt);

    /// <summary>
    /// Генератор соли шифрования
    /// </summary>
    /// <returns>Соль шифрования</returns>
    string GenerateSalt();
}