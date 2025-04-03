namespace Authentication.Application.Authentication.Login;

public class LoginQueryResult(string token)
{
    public string Token { get; private set; } = token;
}
