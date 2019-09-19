namespace SchoolRegister.Infrastructure.Dispatchers.Commands
{
    public class ChangeUserPassword : AuthenticatedCommandBase
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}