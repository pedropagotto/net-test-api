using FluentValidation;

namespace Authentication.Application.User.ListUsers;

public class ListUsersQueryValidator: AbstractValidator<ListUsersQuery>
{
    public ListUsersQueryValidator()
    {
        RuleFor(x => x.Year)
            .NotEmpty()
            .WithMessage("Ano é obrigatório")
            .GreaterThan(2015)
            .WithMessage("O ano deverá ser maior que 2015");
    }
}
