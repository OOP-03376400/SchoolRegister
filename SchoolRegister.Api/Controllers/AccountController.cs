using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Infrastructure.Dispatchers.Commands;
using SchoolRegister.Infrastructure.Dispatchers;
using Microsoft.Extensions.Caching.Memory;
using SchoolRegister.Infrastructure.Extensions;
using System;
using SchoolRegister.Infrastructure.Handlers.Users;

namespace SchoolRegister.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;

        public AccountController(IMemoryCache cache,IDispatcher Dispatcher) : base(Dispatcher)
        {
            _cache = cache;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            command.TokenId = Guid.NewGuid();
            await DispatchAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
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