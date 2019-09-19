using System.Threading.Tasks;
using SchoolRegister.Infrastructure.Dispatchers.Commands;
using SchoolRegister.Infrastructure.Queries;

namespace SchoolRegister.Infrastructure.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public Dispatcher(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }
        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            return await _queryDispatcher.QueryAsync<TResult>(query);
        }

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            await _commandDispatcher.SendAsync(command);
        }
    }
}