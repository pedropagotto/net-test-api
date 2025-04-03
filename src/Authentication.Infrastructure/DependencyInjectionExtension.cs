using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Infrastructure;

public static class DependencyInjectionExtension
{
     public static IServiceCollection AddInfrastructure(this IServiceCollection services)
     {
            // services.AddTransient<IProductRepository, ProductRepository>();
    
            return services;
     }
}
