namespace Authentication.Domain.Abstractions;

public interface IRepository<T> where T : class
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<T?> UpdateAsync(int id, T entity, CancellationToken cancellationToken = default);
    Task<T?> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<T?> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<List<T>> GetAllAsync(int page = 0, int pageSize = 25, CancellationToken cancellationToken = default);
}
