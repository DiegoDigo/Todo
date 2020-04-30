using System.Threading.Tasks;
using Todo.Domain.UserContext.Entities;

namespace Todo.Domain.UserContext.Repositories
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<bool> ExistEmail(string email);
    }
}