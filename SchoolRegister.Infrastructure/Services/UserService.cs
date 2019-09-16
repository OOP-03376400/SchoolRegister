using System;
using SchoolRegister.Core.Repositories;
using SchoolRegister.Infrastructure.DTO;
using SchoolRegister.Core.Domain;
using System.Threading.Tasks;

namespace SchoolRegister.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName
            };
        }

        public async Task RegisterAsync(string email, string username,string role, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(Guid.NewGuid(),email,username,"student", password, salt);
            await _userRepository.AddAsync(user);
        }
    }
}