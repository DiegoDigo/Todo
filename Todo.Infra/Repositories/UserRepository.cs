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

        public async Task<bool> ExistEmail(string email) => await _context.Users.AsNoTracking().AnyAsync(UserQuery.FindByEmail(email));
    }
}