using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.TodoContext.Command;
using Todo.Domain.TodoContext.Handler;
using Todo.Domain.TodoContext.Repositories;
using Todo.Shared.Command;

namespace Todo.Api.Controller
{
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly TodoHandler _handler;
        private readonly ITodoRepository _todoRepository;

        public TodoController(TodoHandler handler, ITodoRepository todoRepository)
        {
            _handler = handler;
            _todoRepository = todoRepository;
        }

        [HttpPost, ApiVersion("1.0")]
        public async Task<ActionResult<CommandResult>> Create([FromBody] CreateNewTodoCommand command)
        {
            var resp = await _handler.Handler(command);

            if (resp.Success)
            {
                return StatusCode(201, resp);
            }

            return resp.Content == null ? StatusCode(404, resp) : BadRequest(resp);
        }

        [HttpGet("{userId}"), ApiVersion("1.0")]
        public async Task<ActionResult<CommandResult>> Create(string userId)
        {
            var resp = await _todoRepository.GetAll(userId);

            return resp.Count > 0
                ? StatusCode(200, new CommandResult(true, "Lista de tarefas", resp))
                : StatusCode(404, new CommandResult(false, "Nao encontramos tarefas para o usuario.", null));
        }

        [HttpPut, ApiVersion("1.0")]
        public async Task<ActionResult<CommandResult>> Update([FromBody] UpdateTodoCommand command)
        {
            var resp = await _handler.Handler(command);
            if (resp.Success)
            {
                return Ok(resp);
            }

            return resp.Content == null ? StatusCode(204, resp) : BadRequest(resp);
        }

        [HttpPost("done"), ApiVersion("1.0")]
        public async Task<ActionResult<CommandResult>> MakeDone([FromBody] MakeDoneCommand command)
        {
            var resp = await _handler.Handler(command);

            if (resp.Success)
            {
                return StatusCode(200, resp);
            }

            return resp.Content == null ? StatusCode(404, resp) : BadRequest(resp);
        }


        [HttpPost("undone"), ApiVersion("1.0")]
        public async Task<ActionResult<CommandResult>> MakeDone([FromBody] MakeUndoneCommand command)
        {
            var resp = await _handler.Handler(command);

            if (resp.Success)
            {
                return StatusCode(200, resp);
            }

            return resp.Content == null ? StatusCode(404, resp) : BadRequest(resp);
        }
    }
}