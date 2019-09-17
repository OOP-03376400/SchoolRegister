using System.Threading.Tasks;
using SchoolRegister.Infrastructure.Commands;
using SchoolRegister.Infrastructure.Services;

namespace SchoolRegister.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;
        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Email,command.Username,command.Role,command.Password);
        }
    }
}