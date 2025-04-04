using Authentication.Domain.Abstractions;
using Authentication.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure.Data;

public abstract class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    protected readonly DbSet<T> DbSet;
    protected readonly IQueryable<T> ContextReadonly;

    public Repository(DbContext context)
    {
        _context = context;
        DbSet = context.Set<T>();
        ContextReadonly = DbSet.AsNoTracking();

    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<T?> UpdateAsync(int id, T entity, CancellationToken cancellationToken = default)
    {
        DbSet.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<T?> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetAsync(id, cancellationToken);
        if (entity is null)
            return null;

        DbSet.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<T?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync(id, cancellationToken);
    }

    public async Task<List<T>> GetAllAsync(int page = 0, int pageSize = 25, CancellationToken cancellationToken = default)
    {
        return await ContextReadonly.Paginate(page, pageSize).ToListAsync(cancellationToken);
    }
}
