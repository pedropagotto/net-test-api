using Authentication.Application.Authentication;
using Authentication.Application.User;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
