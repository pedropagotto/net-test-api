using Authentication.Domain.Enums;

namespace Authentication.Api.Models.Response.User;

public class ListUsersResponse
{
    public List<UserResponseItem> Users { get; set; }
}

public class UserResponseItem
{
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    public EUserStatus Status { get; set; }
}