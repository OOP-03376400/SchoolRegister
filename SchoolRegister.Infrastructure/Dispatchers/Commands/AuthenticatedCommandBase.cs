using System;

namespace SchoolRegister.Infrastructure.Dispatchers.Commands
{
    public class AuthenticatedCommandBase : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
    }
}