using System.Threading.Tasks;
using AutoMapper;
using Todo.Domain.UserContext.Command.Input;
using Todo.Domain.UserContext.Command.Output;
using Todo.Domain.UserContext.Entities;
using Todo.Domain.UserContext.Entities.Enums;
using Todo.Domain.UserContext.Reposirtories;
using Todo.Shared.Command;
using Todo.Shared.Handler;

namespace Todo.Domain.UserContext.Handler
{
    public class UserHandler : IHandler<CreateNewUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handler(CreateNewUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new CommandResult(false, "Ops, erro ao criar o usuario.", command.Notifications);
            }

            var user = _mapper.Map<User>(command);
            user.EncryptPassword();
            user.ChooseRole(ERole.COSTUMER);
            
            await _userRepository.Create(user);

            var resp = _mapper.Map<CreateNewUserResponse>(user);
            
            return new CommandResult(true, "Usuario criado com sucesso.", resp);
        }
    }
}