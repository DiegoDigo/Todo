using System;
using System.Threading.Tasks;
using Todo.Domain.TodoContext.Command;
using Todo.Domain.TodoContext.Entities;
using Todo.Domain.TodoContext.Repositories;
using Todo.Domain.UserContext.Repositories;
using Todo.Shared.Command;
using Todo.Shared.Handler;

namespace Todo.Domain.TodoContext.Handler
{
    public class TodoHandler : IHandler<CreateNewTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MakeDoneCommand>,
        IHandler<MakeUndoneCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITodoRepository _todoRepository;

        public TodoHandler(IUserRepository userRepository, ITodoRepository todoRepository)
        {
            _userRepository = userRepository;
            _todoRepository = todoRepository;
        }

        public async Task<CommandResult> Handler(CreateNewTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new CommandResult(false, "Ops, erro ao criar nova tarefa.", command.Notifications);
            }

            var user = await _userRepository.FindUserById(new Guid(command.UserId));

            if (user == null)
            {
                return new CommandResult(false, "Ops, usuario nao encontrado", null);
            }

            var todoItem = new TodoItem(user.Id.ToString(), command.Title, command.Description, command.EndingDate);
            todoItem.VerifyDeadline();

            await _todoRepository.Create(todoItem);


            return new CommandResult(true, "Tarefa criada com sucesso.", todoItem);
        }

        public async Task<CommandResult> Handler(UpdateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new CommandResult(false, "Ops, erro ao criar nova tarefa.", command.Notifications);
            }

            var todo = await _todoRepository.GetByIdAndUserID(new Guid(command.Id), command.UserId);
            if (todo == null)
            {
                return new CommandResult(false, "Tarefa nao encontrada.", null);
            }

            if (!string.IsNullOrEmpty(command.Title))
            {
                todo.ChooseTitle(command.Title);
            }

            if (!string.IsNullOrEmpty(command.Description))
            {
                todo.ChooseDescription(command.Description);
            }

            todo.VerifyDeadline();
            await _todoRepository.Update(todo);
            return new CommandResult(true, "Tarefa atualizado sucesso.", todo);
        }

        public async Task<CommandResult> Handler(MakeDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new CommandResult(false, "Ops, erro ao concluir a tarefa.", command.Notifications);
            }   
            
            var todo = await _todoRepository.GetByIdAndUserID(new Guid(command.Id), command.UserId);
            if (todo == null)
            {
                return new CommandResult(false, "Tarefa nao encontrada.", null);
            }
            
            todo.MarkDone();
            await _todoRepository.Update(todo);
            return new CommandResult(true, "Tarefa concluida com sucesso", todo);

        }

        public async Task<CommandResult> Handler(MakeUndoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new CommandResult(false, "Ops, erro ao concluir a tarefa.", command.Notifications);
            }   
            
            var todo = await _todoRepository.GetByIdAndUserID(new Guid(command.Id), command.UserId);
            if (todo == null)
            {
                return new CommandResult(false, "Tarefa nao encontrada.", null);
            }
            
            todo.MarkUndone();
            await _todoRepository.Update(todo);
            return new CommandResult(true, "Tarefa concluida com sucesso", todo);
        }
    }
}