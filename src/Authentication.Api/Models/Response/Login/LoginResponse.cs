using Authentication.Application.Authentication.Login;

namespace Authentication.Api.Models.Response.Login;

public class LoginResponse
{
    /// <summary>
    /// JWT Token authenticated
    /// </summary>
    public string Token { get; set; }

    public static LoginResponse From(LoginQueryResult result) => new LoginResponse()
    {
        Token = result.Token,
    };
}
