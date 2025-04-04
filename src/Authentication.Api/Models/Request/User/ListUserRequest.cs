using Authentication.Domain.Abstractions;

namespace Authentication.Api.Models.Request.User;

public class ListUserRequest: PaginationRequest
{
    public int Year { get; set; }
    
    public string? Name { get; set; }
    
    public string? CreatedAtOrderBy { get; set; }
}
