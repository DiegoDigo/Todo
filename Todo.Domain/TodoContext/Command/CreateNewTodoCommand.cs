using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Shared.Command;

namespace Todo.Domain.TodoContext.Command
{
    public class CreateNewTodoCommand : Notifiable, ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EndingDate { get; set; }
        public string UserId { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3, "title", "O Titulo deve conter no minimo 3 caracteres.")
                    .HasMaxLen(Title, 20, "title", "O Titulo deve conter no maximo 20 caracteres.")
                    .HasMaxLen(Description, 150, "description", "A Descricao deve conter no maximo 150 caracteres.")
                    .IsNotNull(EndingDate, "endingDate", "A data entraga nao pode ser nulla.")
                    .IsNotNullOrEmpty(UserId, "userId", "O Id do usuario nao pode ser nullo ou vazio.")
            );
        }
    }
}