using System.Threading.Tasks;
using SchoolRegister.Infrastructure.Commands;
using SchoolRegister.Infrastructure.Queries;

namespace SchoolRegister.Infrastructure.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}