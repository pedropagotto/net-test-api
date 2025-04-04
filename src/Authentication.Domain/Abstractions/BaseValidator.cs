namespace Authentication.Domain.Abstractions;

public abstract class BaseValidator<T>
{
    public abstract Result<T> Validate();
}
