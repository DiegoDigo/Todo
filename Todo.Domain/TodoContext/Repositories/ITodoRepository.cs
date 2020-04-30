using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.TodoContext.Entities;

namespace Todo.Domain.TodoContext.Repositories
{
    public interface ITodoRepository
    {
        Task Create(TodoItem todoItem);
        Task<ICollection<TodoItem>> GetAll(string userId);
        Task<TodoItem> GetByIdAndUserID(Guid id, string userId);
        Task Update(TodoItem todoItem);
    }
}