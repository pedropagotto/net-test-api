using Authentication.Application.Authentication.Login;

namespace Authentication.Application.Authentication;

public interface IAuthenticationService
{
    Task<LoginQueryResult> Login(LoginQuery loginQuery);
}
