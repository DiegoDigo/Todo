using System;
using Todo.Domain.UserContext.Entities;
using Todo.Shared.Entities;

namespace Todo.Domain.TodoConext.Entities
{
    public class TodoItem : Entity
    {
        public User User { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Done { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime EndingDate { get; private set; }
        public DateTime? CompletionDate { get; private set; }
        public bool Deadline { get; private set; }
        public Guid UserId { get; private set; }

        public TodoItem()
        {
        }

        public TodoItem(User user, string title, string description, DateTime endingDate)
        {
            User = user;
            Title = title;
            Description = description;
            Done = false;
            CreateDate = DateTime.Now.Date;
            EndingDate = endingDate;
        }


        public void MarkDone()
        {
            this.Done = true;
            this.CompletionDate = DateTime.Now.Date;
            this.Deadline = this.CompletionDate?.Date < this.EndingDate.Date;
        }

        public void MarkUndone()
        {
            this.Done = false;
            this.CompletionDate = null;
            this.Deadline = DateTime.Now.Date < this.EndingDate.Date;
        }

        public void ExtendDeadline(DateTime newDeadline)
        {
            this.EndingDate = newDeadline;
        }
    }
}