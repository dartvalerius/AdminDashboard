namespace AD.Application.Interfaces;

/// <summary>
/// Интерфейс спецификации для фильтрации данных
/// </summary>
/// <typeparam name="TEntity">Тип данных спецификации</typeparam>
public interface ISpecification<TEntity>
    where TEntity : class
{
    IList<string> Includes { get; }

    /// <summary>
    /// Применение фильтрации для преданного запроса
    /// </summary>
    /// <param name="query">Запрос к данным</param>
    /// <returns>Отфильтрованный запрос</returns>
    IQueryable<TEntity> Apply(IQueryable<TEntity> query);
}