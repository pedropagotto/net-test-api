using System.Reflection;
using Authentication.Api.Configurations.Extensions;
using Authentication.Application;
using Authentication.Domain.Models.Configurations;
using Authentication.Infrastructure;


var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var config = new ConfigurationBuilder()
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{environmentName}.json", true, true)
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
    .AddEnvironmentVariables()
    .Build();

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddCorsConfiguration();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var configurations = config.GetSection("Configurations").Get<ConfigurationModel>();
configurations!.ConnectionString =  builder.Configuration.GetConnectionString("PostgresSQL")
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
