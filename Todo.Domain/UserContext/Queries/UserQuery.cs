using System;
using System.Linq.Expressions;
using Todo.Domain.UserContext.Entities;

namespace Todo.Domain.UserContext.Queries
{
    public static class UserQuery
    {
        public static Expression<Func<User, bool>> FindByEmail(string email)
        {
            return x => x.Email.Address == email;
        }
        
        public static Expression<Func<User, bool>> FindById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}