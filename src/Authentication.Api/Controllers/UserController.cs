using Authentication.Api.Models.Request.Login;
using Authentication.Api.Models.Request.User;
using Authentication.Api.Models.Response.Login;
using Authentication.Application.Authentication;
using Authentication.Application.User;
using Authentication.Application.User.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
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
        public async Task<ActionResult<int>> Post([FromBody] CreateUserRequest request)
        {
            var command = request.ToCommand();
            if(!command.Success)
                return BadRequest(command.Errors);
            
            var result = await _userService.CreteUserAsync(command.Value!);
            if(!result.Success)
                return BadRequest(result.Errors);
            
            return Ok(new { userId = result.Value });
        }
    }
}
