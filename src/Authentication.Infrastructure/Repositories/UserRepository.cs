using Authentication.Domain.Abstractions;
using Authentication.Domain.Entities;
using Authentication.Domain.Repositories;
using Authentication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : Repository<User>(context), IUserRepository
{

}
