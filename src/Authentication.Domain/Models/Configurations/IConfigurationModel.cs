namespace Authentication.Domain.Models.Configurations;

public interface IConfigurationModel
{
    string AuthSecret { get; set; }
    string ConnectionString { get; set; }
}
