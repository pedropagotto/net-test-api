using System.Linq.Expressions;

namespace Authentication.Domain.Abstractions;

public interface IRepository<T> where T : class
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<T?> UpdateAsync(int id, T entity, CancellationToken cancellationToken = default);
    Task<T?> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<T?> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<List<T>> GetAllAsync(int page = 0, int pageSize = 25, CancellationToken cancellationToken = default);
    
    Task<List<TSelect>> FiltersAsync<TSelect>(Expression<Func<T, bool>> predicate, Expression<Func<T, TSelect>> mapper, int page = 0, int pageSize = 25, CancellationToken cancellationToken = default);
}
