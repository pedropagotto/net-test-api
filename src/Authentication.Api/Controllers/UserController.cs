using Authentication.Api.Models.Request.User;
using Authentication.Api.Models.Response.User;
using Authentication.Application.User;
using Authentication.Domain.Abstractions;
using Microsoft.AspNetCore.Authorization;
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
        
        /// <summary>
        /// Endpoint for List total consolidate users
        /// </summary>
        /// <param name="year"></param>
        /// <returns>List consolidated users</returns>
        [HttpGet("list-total-consolidate-users")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(TotalConsolidateUsersResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorMessage>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<ErrorMessage>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TotalConsolidateUsersResponse>> Get([FromQuery] int year)
        {
            if(year <= 0)
                year = DateTime.Now.Year;
            
            var result = await _userService.GetTotalConsolidateUsers(year);
            if(!result.Success)
                return BadRequest(result.Errors);
            
            return Ok(TotalConsolidateUsersResponse.Map(result.Value!));
        }
        
        /// <summary>
        /// Endpoint for List Users
        /// </summary>
        /// <param name="year"></param>
        /// <returns>List consolidated users</returns>
        [HttpGet("list-users")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(TotalConsolidateUsersResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorMessage>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<ErrorMessage>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TotalConsolidateUsersResponse>> Get([FromQuery] ListUserRequest request)
        {
            
            //var result = await _userService.GetTotalConsolidateUsers(year);
            // if(!result.Success)
            //     return BadRequest(result.Errors);
            // TotalConsolidateUsersResponse.Map(result.Value!)
            return Ok();
        }
    }
}
