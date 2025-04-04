using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.Application.Authentication.Login;
using Authentication.Domain.Abstractions;
using Authentication.Domain.Extensions;
using Authentication.Domain.Models.Configurations;
using Authentication.Domain.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IConfigurationModel _configuration;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IConfigurationModel configuration, IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;

    }
    public async Task<Result<LoginQueryResult>> Login(LoginQuery loginQuery)
    {
        var userLogin = await _userRepository.GetByEmailAndPassword(loginQuery.Email, loginQuery.Password.EncryptPassword());
        
        if (userLogin == null)
            return Result.Error<LoginQueryResult>("O usuário pode estar desativado ou com os dados de login e senha invalidos");

        var token = GetJwtToken(userLogin.Email, userLogin.User.Name, userLogin.Id.ToString());
        return Result.Ok(new LoginQueryResult(token));
    }

    private string GetJwtToken(string email, string name, string userId)
    {
        var handler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Email, email),
                new("fullName", name),
                new("userId", userId)
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.AuthSecret)), SecurityAlgorithms.HmacSha256Signature)
        };
        
        return handler.WriteToken(new JwtSecurityTokenHandler().CreateToken(tokenDescriptor));
    }
}
