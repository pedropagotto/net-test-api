using Authentication.Application.User.Create;
using Authentication.Application.User.TotalConsolidateUsers;
using Authentication.Domain.Abstractions;

namespace Authentication.Application.User;

public interface IUserService
{
    Task<Result<int>> CreteUserAsync(CreateUserCommand command);
    
    Task<Result<TotalConsolidateUsersResult>> GetTotalConsolidateUsers(int year);

}
