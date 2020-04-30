using Todo.Domain.UserContext.Entities;

namespace Todo.Domain.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}