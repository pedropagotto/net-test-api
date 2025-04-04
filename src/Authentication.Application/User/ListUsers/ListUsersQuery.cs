using Authentication.Application.Extensions;
using Authentication.Domain.Abstractions;

namespace Authentication.Application.User.ListUsers;

public class ListUsersQuery: BaseValidator<ListUsersQuery>
{
    public int Year { get; set; }
    
    public string? Name { get; set; }
    
    public string? CreatedAtOrderBy { get; set; }
    
    public int Page { get; set; } = 1;
    
    public int PageSize { get; set; } = 25;
    
    public override Result<ListUsersQuery> Validate()
    {
        var validator = new ListUsersQueryValidator().Validate(this).ToResult();
        return validator.Success ? Result.Ok(this) : Result.Error<ListUsersQuery>(validator.Errors);
    }
}
