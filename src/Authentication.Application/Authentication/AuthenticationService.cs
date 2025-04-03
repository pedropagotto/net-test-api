using Authentication.Application.Authentication.Login;

namespace Authentication.Application.Authentication;

public class AuthenticationService: IAuthenticationService
{
    public async Task<LoginQueryResult> Login(LoginQuery loginQuery)
    {
        throw new NotImplementedException();
    }
}
