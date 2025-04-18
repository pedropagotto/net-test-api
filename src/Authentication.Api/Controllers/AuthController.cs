using Authentication.Api.Models.Request.Login;
using Authentication.Api.Models.Response.Login;
using Authentication.Application.Authentication;
using Authentication.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

        }

        /// <summary>
        /// Endpoint for login
        /// </summary>
        /// <param name="request"></param>
        /// <returns>token</returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorMessage>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<ErrorMessage>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LoginResponse>> Post([FromBody] LoginRequest request)
        {
            var query = request.ToQuery();
            if(!query.Success)
                return BadRequest(query.Errors);
            
            var result = await _authenticationService.Login(query.Value!);
            if(!result.Success)
                return BadRequest(result.Errors);
            
            return Ok(LoginResponse.From(result.Value!));
        }
    }
}
