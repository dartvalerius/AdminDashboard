namespace AD.Application.ViewModels.Client;

/// <summary>
/// Модель отображения списка клиентов
/// </summary>
public class ClientListVm
{
    /// <summary>
    /// Список клиентов
    /// </summary>
    public IList<ClientListItemVm> Clients { get; set; } = [];

    /// <summary>
    /// Количество клиентов в ответе
    /// </summary>
    public int Count { get; set; }
}