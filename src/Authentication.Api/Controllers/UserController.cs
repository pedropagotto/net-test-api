using Authentication.Api.Models.Request.Login;
using Authentication.Api.Models.Request.User;
using Authentication.Api.Models.Response.Login;
using Authentication.Api.Models.Response.User.Create;
using Authentication.Application.Authentication;
using Authentication.Application.User;
using Authentication.Application.User.Create;
using Authentication.Domain.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        /// <summary>
        /// Endpoint for create user
        /// </summary>
        /// <param name="request"></param>
        /// <returns>id of user created</returns>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorMessage>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<ErrorMessage>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateUserResponse>> Post([FromBody] CreateUserRequest request)
        {
            var command = request.ToCommand();
            if(!command.Success)
                return BadRequest(command.Errors);
            
            var result = await _userService.CreteUserAsync(command.Value!);
            if(!result.Success)
                return BadRequest(result.Errors);
            
            return Ok(CreateUserResponse.Map(result.Value));
        }
    }
}
