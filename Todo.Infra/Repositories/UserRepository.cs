using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.UserContext.Entities;
using Todo.Domain.UserContext.Queries;
using Todo.Domain.UserContext.Repositories;
using Todo.Infra.Context;

namespace Todo.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoDbContext _context;

        public UserRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistEmail(string email) =>
            await _context.Users.AsNoTracking().AnyAsync(UserQuery.FindByEmail(email));

        public async Task<User> FindUserByEmail(string email) =>
            await _context.Users.AsNoTracking().Where(UserQuery.FindByEmail(email)).FirstOrDefaultAsync();

        public async Task<User> FindUserById(Guid id) =>
            await _context.Users.AsNoTracking().Where(UserQuery.FindById(id)).FirstOrDefaultAsync();
    }
}