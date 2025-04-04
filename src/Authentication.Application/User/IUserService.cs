using Authentication.Application.User.Create;
using Authentication.Domain.Abstractions;

namespace Authentication.Application.User;

public interface IUserService
{
    Task<Result<int>> CreteUserAsync(CreateUserCommand command);

}
