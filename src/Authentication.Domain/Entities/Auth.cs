using Authentication.Domain.Abstractions;

namespace Authentication.Domain.Entities;

public class Auth : BaseAudit
{
    public Auth()
    {
    }

    public Auth(string email, string password, int userId)
    {
        Email = email;
        Password = password;
        UserId = userId;
    }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public Auth SetEmail(string email)
    {
        Email = email;
        return this;
    }

    public Auth SetPassword(string password)
    {
        Password = password;
        return this;
    }
}
