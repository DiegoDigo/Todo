using Flunt.Notifications;
using Flunt.Validations;
using Todo.Shared.Command;

namespace Todo.Domain.TodoContext.Command
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Id { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMaxLen(Description, 150, "Description", "A Descricao deve conter no maximo 150 caracteres.")
                    .HasMaxLen(Title, 20, "title", "O Titulo deve conter no maximo 20 caracteres.")
                    .IsNotNullOrEmpty(Id, "id", "O Id da tarefa nao pode ser nullo ou vazio.")
                    .IsNotNullOrEmpty(UserId, "userId", "O Id do usuario nao pode ser nullo ou vazio.")
            );
        }
    }
}