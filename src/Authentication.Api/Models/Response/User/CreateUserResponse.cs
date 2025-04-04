namespace Authentication.Api.Models.Response.User;

public class CreateUserResponse
{
    public int UserId { get; set; }
    
    public static CreateUserResponse Map(int userId) => new () { UserId = userId };
}
