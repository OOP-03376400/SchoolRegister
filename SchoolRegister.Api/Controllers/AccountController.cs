using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Infrastructure.Dispatchers.Commands;
using SchoolRegister.Infrastructure.Dispatchers;

namespace SchoolRegister.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {

        public AccountController(Dispatcher Dispatcher) : base(Dispatcher)
        {

        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await _Dispatcher.SendAsync(command);

            return NoContent();
        }  

    }
}