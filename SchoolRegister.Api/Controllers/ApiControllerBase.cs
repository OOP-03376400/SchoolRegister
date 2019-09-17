using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Infrastructure.Commands;
using SchoolRegister.Infrastructure.Queries;

namespace SchoolRegister.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;
        protected readonly IQueryDispatcher QueryDispatcher;

        protected ApiControllerBase(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            CommandDispatcher = commandDispatcher;
            QueryDispatcher = queryDispatcher;

        }        
    }
}