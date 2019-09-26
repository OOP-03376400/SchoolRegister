using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Infrastructure.Dispatchers;
using SchoolRegister.Infrastructure.Dispatchers.Commands;
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
        [HttpGet("{email}")]
        public async Task<UserDto> Get([FromRoute] GetUser query)
        {
            return await _Dispatcher.QueryAsync<UserDto>(query);
        } 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.BrowseAsync();

            return Json(users);
        }
            
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await DispatchAsync(command);
            return Created($"Users/{command.Email}", null); //operacja get Users/email
        }
        

    }
}