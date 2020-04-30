using System.Threading.Tasks;
using AutoMapper;
using Flunt.Notifications;
using Todo.Domain.Services;
using Todo.Domain.UserContext.Command.Input;
using Todo.Domain.UserContext.Command.Output;
using Todo.Domain.UserContext.Entities;
using Todo.Domain.UserContext.Entities.Enums;
using Todo.Domain.UserContext.Repositories;
using Todo.Shared.Command;
using Todo.Shared.Handler;
using Todo.Shared.Util;

namespace Todo.Domain.UserContext.Handler
{
    public class UserHandler : Notifiable,
        IHandler<CreateNewUserCommand>,
        IHandler<SignInCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserHandler(IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<CommandResult> Handler(CreateNewUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new CommandResult(false, "Ops, erro ao criar o usuario.", command.Notifications);
            }

            if (await _userRepository.ExistEmail(command.Email))
            {
                AddNotification("Email", "O Email já cadastrado.");
                return new CommandResult(false, "Ops, erro ao criar o usuario.", Notifications);
            }

            var user = _mapper.Map<User>(command);
            user.EncryptPassword();
            user.ChooseRole(ERole.COSTUMER);

            await _userRepository.Create(user);

            var resp = _mapper.Map<CreateNewUserResponse>(user);

            return new CommandResult(true, "Usuario criado com sucesso.", resp);
        }

        public async Task<CommandResult> Handler(SignInCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new CommandResult(false, "Ops, erro ao tentar acessar usuario.", command.Notifications);
            }

            var user = await _userRepository.FindUserByEmail(command.Email);

            if (!PasswordUtil.Verify(command.Password, user.Password))
            {
                return new CommandResult(false, "Usuario ou senha invalido.", null);
            }

            var token = _tokenService.GenerateToken(user);
            return new CommandResult(true, "usuario logado com sucesso.", token);
        }
    }
}