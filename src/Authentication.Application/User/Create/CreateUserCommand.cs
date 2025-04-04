using Authentication.Application.Authentication.Login;
using Authentication.Application.Extensions;
using Authentication.Domain.Abstractions;
using Authentication.Domain.Enums;

namespace Authentication.Application.User.Create;

public class CreateUserCommand: BaseValidator<CreateUserCommand>
{
    public CreateUserCommand(string name,
        string interests,
        string feelings,
        string valuesDescription, 
        string email,
        string password,
        EUserStatus? status = null)
    {
        Name = name;
        Interests = interests;
        Feelings = feelings;
        ValuesDescription = valuesDescription;
        Email = email;
        Password = password;
        Status = status ?? EUserStatus.PENDING;
    }
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string Name { get; set; }

    public int? Age { get; set; }

    public string? Address { get; set; }
    public EUserStatus Status { get; set; }

    public string? OtherInfo { get; set; }

    public string Interests { get; set; }

    public string Feelings { get; set; }

    public string ValuesDescription { get; set; }
    
    public override Result<CreateUserCommand> Validate()
    {
        var validator = new CreateUserCommandValidator().Validate(this).ToResult();
        return validator.Success ? Result.Ok(this) : Result.Error<CreateUserCommand>(validator.Errors);
    }
}
