using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.UserContext.Command.Input;
using Todo.Domain.UserContext.Handler;

namespace Todo.Api.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserHandler _userHandler;

        public UserController(UserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        [HttpPost("")]
        public async Task<ActionResult> Register([FromBody] CreateNewUserCommand command)
        {
            var resp = await _userHandler.Handler(command);
            return resp.Success ? StatusCode(201, resp) : BadRequest(resp);
        }
        
    }
}