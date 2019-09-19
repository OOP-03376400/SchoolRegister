using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Infrastructure.Commands;
using SchoolRegister.Infrastructure.Dispatchers;
using SchoolRegister.Infrastructure.DTO;
using SchoolRegister.Infrastructure.Queries;
using SchoolRegister.Infrastructure.Services;

namespace SchoolRegister.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IDispatcher Dispatcher, IUserService userService) :base(Dispatcher)
        {
            _userService = userService;
        }
        public async Task<UserDto> Get([FromRoute] GetUser query)
        {
            return await _Dispatcher.QueryAsync<UserDto>(query);
        }
        public async Task<IActionResult> Get()
        {
            var users = await _userService.BrowseAsync();

            return Json(users);
        }
            
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _Dispatcher.SendAsync(command);
            return Created($"users/{command.Email}", new object());
        }
        

    }
}