using System.Text;
using Authentication.Domain.Models.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Api.Configurations.Extensions;

public static class JwtExtensions
{
    /// <summary>
    /// Jwt configuration method.
    /// </summary>
    /// <param name="services"></param>
    public static void AddJwtConfig(this IServiceCollection services, ConfigurationModel config)
    {
        var secret = config.AuthSecret;
        var key = Encoding.ASCII.GetBytes(secret);
        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
    }
}