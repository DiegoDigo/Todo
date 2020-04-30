using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.UserContext.Command.Input;
using Todo.Domain.UserContext.Handler;
using Todo.Shared.Command;

namespace Todo.Api.Controller
{
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserHandler _userHandler;

        public UserController(UserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        [HttpPost(""), ApiVersion("1.0")]
        [ProducesResponseType((int) HttpStatusCode.Created)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CommandResult>> Register([FromBody] CreateNewUserCommand command)
        {
            var resp = await _userHandler.Handler(command);
            return resp.Success ? StatusCode(201, resp) : BadRequest(resp);
        }
    }
}