using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolRegister.Infrastructure.DTO;

namespace SchoolRegister.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<IEnumerable<UserDto>> BrowseAsync();
        Task<UserDto> GetAsync(string email);
        Task LoginAsync(string email, string password);
        Task RegisterAsync(string email, string username,string role, string password);
    }
}