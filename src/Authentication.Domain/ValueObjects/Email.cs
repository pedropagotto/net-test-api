namespace Authentication.Domain.ValueObjects;

public class Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty");

        if (!IsValidEmail(value))
            throw new ArgumentException("Invalid email format");

        Value = value;
    }

    private bool IsValidEmail(string email) => email.Contains("@");

    public override bool Equals(object obj)
    {
        if (obj is not Email other)
            return false;

        return Value == other.Value;
    }

    public override int GetHashCode() => Value.GetHashCode();

    public static bool operator ==(Email left, Email right) => Equals(left, right);
    public static bool operator !=(Email left, Email right) => !Equals(left, right);

    public override string ToString() => Value;
}