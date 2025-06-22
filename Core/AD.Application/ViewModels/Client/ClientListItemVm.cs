namespace AD.Application.ViewModels.Client;

/// <summary>
/// Модель отображения элемента списка клиентов
/// </summary>
public class ClientListItemVm
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Баланс
    /// </summary>
    public string Balance { get; set; } = string.Empty;
}