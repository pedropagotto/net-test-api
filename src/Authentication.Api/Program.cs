using System.Reflection;
using Authentication.Api.Configurations.Extensions;
using Authentication.Api.Configurations.Filters;
using Authentication.Api.Configurations.Middlewares;
using Authentication.Application;
using Authentication.Application.Authentication.Login;
using Authentication.Domain.Models.Configurations;
using Authentication.Infrastructure;
using Authentication.Infrastructure.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;


var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var config = ConfigurationBuilderExtensions.GetConfigurations();

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddFiltersConfigurations();
services.AddCorsConfiguration();

services.AddControllers(opt =>
{
    opt.Filters.Add<ModelStateFilter>();
});
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 

var configurations = config.GetSection("Configurations").Get<ConfigurationModel>();
configurations!.ConnectionString = builder.Configuration.GetConnectionString("PostgresSQL")
                                   ?? throw new Exception("ConnectionString not found");

services.AddJwtConfig(configurations);
services.AddApiDi(configurations);
services.AddInfrastructure();
services.AddApplicationServices();
services.AddDataBaseConfiguration(configurations);


#region App

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.AddCustomCors();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

#endregion
