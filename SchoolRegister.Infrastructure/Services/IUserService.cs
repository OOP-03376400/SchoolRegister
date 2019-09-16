using SchoolRegister.Infrastructure.DTO;

namespace SchoolRegister.Infrastructure.Services
{
    public interface IUserService
    {
        UserDto Get(string email);
        void Register(string email, string username,string role, string password);
    }
}