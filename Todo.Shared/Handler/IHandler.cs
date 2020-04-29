using System.Threading.Tasks;
using Todo.Shared.Command;

namespace Todo.Shared.Handler
{
    public interface IHandler<T> where T: ICommand
    {
        Task<CommandResult> Handler(T command);
    }
}