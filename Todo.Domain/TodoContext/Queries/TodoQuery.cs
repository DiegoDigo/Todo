using System;
using System.Linq.Expressions;
using Todo.Domain.TodoContext.Entities;

namespace Todo.Domain.TodoContext.Queries
{
    public static class TodoQuery
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string userId)
        {
            return x => x.UserId == userId;
        }

        public static Expression<Func<TodoItem, bool>> GetByIdAndUserId(Guid id, string userId)
        {
            return x => x.UserId == userId && x.Id == id;
        }
    }
}