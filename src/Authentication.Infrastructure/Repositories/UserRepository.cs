using Authentication.Domain.Entities;
using Authentication.Domain.Repositories;
using Authentication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Authentication.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : Repository<User>(context), IUserRepository
{

    public async Task<Auth?> GetByEmailAndPassword(string email, string password)
    {
        return await context.Authentications.AsNoTracking().Include(x => x.User)
            .FirstOrDefaultAsync(x=> x.Email == email && x.Password == password);;
    }
    public async Task<bool> EmailExistsAsync(string email)
    {
        return await context.Authentications.AsNoTracking().AnyAsync(x => x.Email == email);
    }
}
