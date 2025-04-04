using Authentication.Domain.Abstractions;
using Authentication.Domain.Repositories;
using Authentication.Infrastructure.Data;
using Authentication.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Infrastructure;

public static class DependencyInjectionExtension
{
     public static IServiceCollection AddInfrastructure(this IServiceCollection services)
     {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
    
            return services;
     }
}
