using Authentication.Application.Authentication.Login;
using Authentication.Domain.Abstractions;

namespace Authentication.Api.Models.Request.Login;

public class LoginRequest
{
    /// <summary>
    /// Email to login
    /// </summary>
    /// <example>login@gmail.com</example>
    public string Email { get; set; }
    /// <summary>
    /// Password to login
    /// </summary>
    /// <example>saudhias@lsasokxc</example>
    public string Password { get; set; }

    public Result<LoginQuery> ToQuery()
    {
        return new LoginQuery(Email, Password).Validate();
    }
}
