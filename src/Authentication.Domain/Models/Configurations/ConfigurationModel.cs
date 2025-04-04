namespace Authentication.Domain.Models.Configurations;

public class ConfigurationModel: IConfigurationModel
{
    public string AuthSecret { get; set; }
    public string ConnectionString { get; set; }
}
