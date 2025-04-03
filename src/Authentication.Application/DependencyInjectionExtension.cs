using Authentication.Application.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    
        return services;
    }
}
