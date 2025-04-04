using Authentication.Api.Configurations.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Configurations.Extensions;

public static class FiltersConfigurations
{
    public static void AddFiltersConfigurations(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
        services.AddScoped<ModelStateFilter>();
    }
}
