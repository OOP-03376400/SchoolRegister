using System.Threading.Tasks;

namespace SchoolRegister.Infrastructure.Dispatchers.Commands
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;
    }
}