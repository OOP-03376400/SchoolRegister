using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Infrastructure.Dispatchers;

namespace SchoolRegister.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly IDispatcher _Dispatcher;

        protected ApiControllerBase(IDispatcher Dispatcher)
        {
            _Dispatcher = Dispatcher;
        }        
    }
}