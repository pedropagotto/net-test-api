using Authentication.Api.Configurations.Filters;
using Authentication.Domain.Models.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Configurations.Extensions;

public static class DependencyInjectionExtensions
{
    public static void AddApiDi(this IServiceCollection services, ConfigurationModel configurationModel)
    {
        services.AddSingleton<IConfigurationModel>(configurationModel);
    }
}
