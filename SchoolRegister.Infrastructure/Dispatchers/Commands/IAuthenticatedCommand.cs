using System;

namespace SchoolRegister.Infrastructure.Dispatchers.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }    
    }
}