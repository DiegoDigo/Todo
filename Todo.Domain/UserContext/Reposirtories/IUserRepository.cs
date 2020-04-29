using System.Threading.Tasks;
using Todo.Domain.UserContext.Entities;

namespace Todo.Domain.UserContext.Reposirtories
{
    public interface IUserRepository
    {
        Task Create(User user);
    }
}