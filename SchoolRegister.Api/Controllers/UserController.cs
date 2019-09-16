using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Infrastructure.Commands;
using SchoolRegister.Infrastructure.DTO;
using SchoolRegister.Infrastructure.Services;

namespace SchoolRegister.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userservice)
        {
            _userService = userservice;
        }
        public async Task<UserDto> Get(string email)
            => await _userService.GetAsync(email);

        [HttpPost]
        public async Task Post([FromBody]CreateUser request)
            => await _userService.RegisterAsync(request.Email, request.Username,request.Role, request.Password);

    }
}