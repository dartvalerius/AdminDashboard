namespace AD.Application.Interfaces;

/// <summary>
/// Интерфейс работы с репозиторием
/// </summary>
/// <typeparam name="TEntity">Тип данных репозитория</typeparam>
public interface IRepository<TEntity>
    where TEntity : class
{
    /// <summary>
    /// Получить данные экземпляра заданного типа по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Экземпляр данных заданного типа</returns>
    TEntity? Get(int id);

    /// <summary>
    /// Получить данные экземпляра заданного типа по спецификации
    /// </summary>
    /// <param name="specification">Экземпляр спецификации</param>
    /// <returns>Экземпляр данных заданного типа</returns>
    TEntity? Get(ISpecification<TEntity> specification);

    /// <summary>
    /// Получить список экземпляров заданного типа
    /// </summary>
    /// <returns>Экземпляры данных заданного типа</returns>
    IList<TEntity> List();

    /// <summary>
    /// Получить список экземпляров заданного типа по спецификации
    /// </summary>
    /// <param name="specification"></param>
    /// <returns>Экземпляры данных заданного типа</returns>
    IList<TEntity> List(ISpecification<TEntity> specification);

    /// <summary>
    /// Добавление экземпляра заданного типа в коллекцию
    /// </summary>
    /// <param name="entity">Экземпляр данных заданного типа</param>
    /// <returns>Экземпляр данных заданного типа</returns>
    TEntity Add(TEntity entity);

    /// <summary>
    /// Обновление данных экземпляра заданного типа
    /// </summary>
    /// <param name="entity">Экземпляр данных заданного типа</param>
    void Update(TEntity entity);

    /// <summary>
    /// Удаление данных экземпляра заданного типа из коллекции
    /// </summary>
    /// <param name="entity">Экземпляр данных заданного типа</param>
    void Delete(TEntity entity);
}