using System.Linq.Expressions;
using Authentication.Domain.Entities;
using Authentication.Domain.Enums;
using Authentication.Domain.Repositories;
using Authentication.Domain.Repositories.Projections;
using Authentication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Authentication.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : Repository<User>(context), IUserRepository
{
    public async Task<Auth?> GetByEmailAndPassword(string email, string password)
    {
        return await context.Authentications.AsNoTracking().Include(x => x.User)
            .FirstOrDefaultAsync(x=> x.Email == email && x.Password == password
            && x.User.Status == EUserStatus.ACTIVE);
    }
    public async Task<bool> EmailExistsAsync(string email)
    {
        return await context.Authentications.AsNoTracking().AnyAsync(x => x.Email == email);
    }
    public async Task<int> CountAsync()
    {
        return await context.Users.AsNoTracking().CountAsync();
    }
    public async Task<List<TotalConsolidateUserItemProjection>> GetConsolidatedUsersAsync(int year)
    {
        var result = await context.Users
            .AsNoTracking()
            .Where(x => x.CreatedAt.Year == year)
            .GroupBy(x => x.Status)
            .Select(g => new TotalConsolidateUserItemProjection
            {
                Description = g.Key.ToString(),
                Total = g.Count()
            })
            .ToListAsync();

        return result;
    }


}
