using Flunt.Notifications;
using Flunt.Validations;
using Todo.Shared.Command;

namespace Todo.Domain.UserContext.Command.Input
{
    public class SignInCommand : Notifiable, ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
        
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsEmail(Email, "Email", "Email está invalido.")
                    .HasMaxLen(Email, 160, "Email", "Email deve ter no maximo 16 caracteres.")
                    .HasMinLen(Password, 8, "Senha", "Senha deve ter no minimo 8 caracteres.")
                    .HasMaxLen(Password, 16, "Senha", "Senha deve ter no maximo 16 caracteres.")
            );
        }
    }
}