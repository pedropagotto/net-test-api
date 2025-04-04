using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Authentication.Infrastructure.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationRoot GetConfigurations()
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        return new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{environmentName}.json", true, true)
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
            .AddEnvironmentVariables()
            .Build();
    }
}
