using SchoolRegister.Infrastructure.DTO;
using SchoolRegister.Infrastructure.Queries;
using SchoolRegister.Infrastructure.Services;

namespace SchoolRegister.Infrastructure.Handlers.Users
{
    public class GetUserHandler : IQueryHandler<GetUser, UserDto>
    {

        private readonly IUserService _userService;
        public GetUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public System.Threading.Tasks.Task<UserDto> HandleAsync(GetUser query)
        {
            return _userService.GetAsync(query.Email);   
        }
    }
}