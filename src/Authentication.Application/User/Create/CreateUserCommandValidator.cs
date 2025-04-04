using Authentication.Domain.Repositories;
using FluentValidation;

namespace Authentication.Application.User.Create;

public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Este e-mail é invalido")
            .NotEmpty()
            .WithMessage("Email é obrigatório");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Senha é obrigatório");
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Nome é obrigatório")
            .MinimumLength(3)
            .WithMessage("Nome precisa ter no minimo 3 caracteres");
        
        RuleFor(x => x.Feelings)
            .NotEmpty()
            .WithMessage("Sentimentos são obrigatórios");
        
        RuleFor(x => x.ValuesDescription)
            .NotEmpty()
            .WithMessage("Valores são obrigatórios");
        
        RuleFor(x => x.Interests)
            .NotEmpty()
            .WithMessage("Interesses são obrigatórios");
    }
}
