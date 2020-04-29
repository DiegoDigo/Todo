using System.Threading.Tasks;
using Todo.Domain.UserContext.Entities;
using Todo.Domain.UserContext.Reposirtories;
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
    }
}