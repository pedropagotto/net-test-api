using Authentication.Domain.Abstractions;

namespace Authentication.Infrastructure.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync() 
        => await context.SaveChangesAsync();
}
