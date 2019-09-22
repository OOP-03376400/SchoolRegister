using System.Threading.Tasks;
using SchoolRegister.Infrastructure.Dispatchers.Commands;

namespace SchoolRegister.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}