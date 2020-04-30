using Flunt.Notifications;
using Flunt.Validations;
using Todo.Shared.Command;

namespace Todo.Domain.TodoContext.Command
{
    public class MakeUndoneCommand : Notifiable, ICommand
    {
        public string UserId { get; set; }
        public string Id { get; set; }
        
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Id, "id", "O Id da tarefa nao pode ser nullo ou vazio.")
                    .IsNotNullOrEmpty(UserId, "userId", "O Id do usuario nao pode ser nullo ou vazio.")
                );
        }
    }
}