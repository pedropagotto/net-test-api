using System.Linq.Expressions;
using Authentication.Domain.Abstractions;
using Authentication.Domain.Entities;
using Authentication.Domain.Repositories.Projections;

namespace Authentication.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    
    Task<Auth?> GetByEmailAndPassword(string email, string password);
    
    Task<bool> EmailExistsAsync(string email);

    Task<int> CountAsync();

    Task<List<TotalConsolidateUserItemProjection>> GetConsolidatedUsersAsync(int year);

}
