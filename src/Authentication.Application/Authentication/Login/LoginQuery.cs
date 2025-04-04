using Authentication.Application.Extensions;
using Authentication.Domain.Abstractions;

namespace Authentication.Application.Authentication.Login;

public class LoginQuery: BaseValidator<LoginQuery>
{
    public LoginQuery(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
    public override Result<LoginQuery> Validate()
    {
        var validator = new LoginQueryValidator().Validate(this).ToResult();
        return validator.Success ? Result.Ok(this) : Result.Error<LoginQuery>(validator.Errors);
    }
}
