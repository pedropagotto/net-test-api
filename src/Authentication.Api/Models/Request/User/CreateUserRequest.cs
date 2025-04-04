using Authentication.Application.Authentication.Login;
using Authentication.Application.Extensions;
using Authentication.Application.User.Create;
using Authentication.Domain.Abstractions;
using Authentication.Domain.Enums;

namespace Authentication.Api.Models.Request.User;

public class CreateUserRequest
{
    public required string Email { get; set; }
    
    public required string Password { get; set; }
    
    public required string Name { get; set; }

    public int? Age { get; set; }

    public string? Address { get; set; }
    
    public EUserStatus? Status { get; set; }

    public string? OtherInfo { get; set; }

    public required string Interests { get; set; }

    public required string Feelings { get; set; }

    public required string ValuesDescription { get; set; }

    public Result<CreateUserCommand> ToCommand()
    {
        return new CreateUserCommand(Name,Interests, Feelings, ValuesDescription, Email, Password, Status)
        {
            OtherInfo = OtherInfo,
            Address = Address,
            Age = Age
        }.Validate();
    }
}
