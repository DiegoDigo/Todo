using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.TodoContext.Entities;
using Todo.Domain.TodoContext.Queries;
using Todo.Domain.TodoContext.Repositories;
using Todo.Infra.Context;

namespace Todo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _todoDbContext;

        public TodoRepository(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        public async Task Create(TodoItem todoItem)
        {
            await _todoDbContext.TodoItems.AddAsync(todoItem);
            await _todoDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<TodoItem>> GetAll(string userId) =>
            await _todoDbContext.TodoItems.AsNoTracking()
                .Where(TodoQuery.GetAll(userId))
                .OrderBy(x => x.CreateDate)
                .ToListAsync();

        public async Task<TodoItem> GetByIdAndUserID(Guid id, string userId) =>
            await _todoDbContext.TodoItems
                .AsNoTracking()
                .Where(TodoQuery.GetByIdAndUserId(id, userId))
                .FirstOrDefaultAsync();

        public async Task Update(TodoItem todoItem)
        {
            _todoDbContext.TodoItems.Update(todoItem);
            await _todoDbContext.SaveChangesAsync();
        }
    }
}