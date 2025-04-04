using Authentication.Application.Authentication.Login;
using Authentication.Domain.Abstractions;

namespace Authentication.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public async Task<Result<LoginQueryResult>> Login(LoginQuery loginQuery)
    {
        return Result.Ok<LoginQueryResult>(new LoginQueryResult("uahsdhuads"));
    }
}
