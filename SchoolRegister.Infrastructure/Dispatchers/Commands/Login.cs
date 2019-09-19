
namespace SchoolRegister.Infrastructure.Dispatchers.Commands
{
    public class Login : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}