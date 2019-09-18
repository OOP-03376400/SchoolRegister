using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Infrastructure.Commands;
using SchoolRegister.Infrastructure.Dispatchers;
using SchoolRegister.Infrastructure.DTO;
using SchoolRegister.Infrastructure.Queries;

namespace SchoolRegister.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IDispatcher Dispatcher) :base(Dispatcher)
        {
        }
        public async Task<UserDto> Get([FromRoute] GetUser query)
        {
            return await _Dispatcher.QueryAsync<UserDto>(query);
        }
            

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _Dispatcher.SendAsync(command);
            return Created($"users/{command.Email}", new object());
        }

    }
}