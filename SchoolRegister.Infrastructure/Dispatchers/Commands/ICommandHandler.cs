using System.Threading.Tasks;

namespace SchoolRegister.Infrastructure.Dispatchers.Commands
{
    public interface ICommandHandler<T> where T : ICommand 
    {
        Task HandleAsync(T command); 
    }
}