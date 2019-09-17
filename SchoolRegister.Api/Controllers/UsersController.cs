using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Infrastructure.Commands;
using SchoolRegister.Infrastructure.DTO;
using SchoolRegister.Infrastructure.Queries;
using SchoolRegister.Infrastructure.Services;

namespace SchoolRegister.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userservice,ICommandDispatcher commandDispatcher,IQueryDispatcher queryDispatcher) :base(commandDispatcher,queryDispatcher)
        {
        }
        public async Task<UserDto> Get([FromRoute] GetUser query)
            => await QueryDispatcher.QueryAsync<UserDto>(query);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Created($"users/{command.Email}", new object());
        }

    }
}