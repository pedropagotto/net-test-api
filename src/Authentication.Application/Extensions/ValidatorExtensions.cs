using Authentication.Domain.Abstractions;
using FluentValidation.Results;

namespace Authentication.Application.Extensions;

public static class ValidatorExtensions
{
    public static Result ToResult(this ValidationResult validationResult)
    {
        return validationResult.IsValid ? Result.Ok() : Result.Error(validationResult.Errors.Select(x => new ErrorMessage(x.ErrorMessage)).ToList());
    }
}
