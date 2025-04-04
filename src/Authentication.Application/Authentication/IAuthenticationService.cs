using Authentication.Application.Authentication.Login;
using Authentication.Domain.Abstractions;

namespace Authentication.Application.Authentication;

public interface IAuthenticationService
{
    Task<Result<LoginQueryResult>> Login(LoginQuery loginQuery);
}
