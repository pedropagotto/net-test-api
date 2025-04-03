namespace Authentication.Api.Configurations.Extensions;

public static class CorsExtensions
{
    public static void AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors(o => o.AddPolicy("Cors", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));
    }

    public static void AddCustomCors(this WebApplication app)
    {
        app.UseCors("Cors");
    }
}
