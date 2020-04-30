using System;
using Todo.Shared.Entities;

namespace Todo.Domain.TodoContext.Entities
{
    public class TodoItem : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Done { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime EndingDate { get; private set; }
        public DateTime? CompletionDate { get; private set; }
        public bool Deadline { get; private set; }
        public string UserId { get; private set; }

        public TodoItem()
        {
        }

        public TodoItem(string userId, string title, string description, DateTime endingDate)
        {
            UserId = userId;
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
            this.VerifyDeadline();
        }

        public void MarkUndone()
        {
            this.Done = false;
            this.CompletionDate = null;
            this.VerifyDeadline();
        }

        public void ExtendDeadline(DateTime newDeadline)
        {
            this.EndingDate = newDeadline;
        }

        public void VerifyDeadline()
        {
            this.Deadline = DateTime.Now.Date < this.EndingDate.Date;
        }
        
        public void ChooseTitle(string title)
        {
            this.Title = title;
        }
        
        public void ChooseDescription(string description)
        {
            this.Description = description;
        }
    }
}