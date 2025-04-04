using Authentication.Domain.Abstractions;
using Authentication.Domain.ValueObjects;

namespace Authentication.Domain.Entities;

public class Auth : BaseAudit
{
    private Auth()
    {
    }

    public Auth(Email email, string password)
    {
        Email = email;
        Password = password;
    }
    public Email Email { get; private set; }
    public string Password { get; private set; }

    public int UserId { get; set; }
    public virtual User User { get; private set; } = null!;

    public Auth SetEmail(string email)
    {
        Email = new Email(email);
        return this;
    }

    public Auth SetPassword(string password)
    {
        Password = password;
        return this;
    }
}
