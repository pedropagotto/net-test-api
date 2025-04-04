using FluentValidation;

namespace Authentication.Application.Authentication.Login;

public class LoginQueryValidator: AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Email é invalido")
            .NotEmpty()
            .WithMessage("Email é obrigatório");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Senha é obrigatório");
    }
}
