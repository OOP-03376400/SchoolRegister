using System.Threading.Tasks;
using SchoolRegister.Infrastructure.DTO;

namespace SchoolRegister.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserDto> GetAsync(string email);
        Task RegisterAsync(string email, string username,string role, string password);
    }
}