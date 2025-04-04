namespace Authentication.Domain.Abstractions;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
