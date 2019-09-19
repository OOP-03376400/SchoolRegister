using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Infrastructure.Dispatchers;
using SchoolRegister.Infrastructure.Dispatchers.Commands;

namespace SchoolRegister.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly IDispatcher _Dispatcher;
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ? 
            Guid.Parse(User.Identity.Name) : 
            Guid.Empty;

        protected ApiControllerBase(IDispatcher Dispatcher)
        {
            _Dispatcher = Dispatcher;
        }
        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command is IAuthenticatedCommand authenticatedCommand)
            {
                authenticatedCommand.UserId = UserId;
            }
            await _Dispatcher.SendAsync(command);
        }        
    }
}