using Authentication.Domain.Models.Configurations;
using Authentication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Api.Configurations.Extensions;

public static class DatabaseConfigurationExtension
{
    public static void AddDataBaseConfiguration(this IServiceCollection services, ConfigurationModel configuration)
    {
        services.AddDbContext<AppDbContext>(x =>
        {
            x.UseNpgsql(configuration.ConnectionString, b
                => b.MigrationsAssembly("Authentication.Api"));
        });
    }
}
