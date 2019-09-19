using System;
using SchoolRegister.Core.Repositories;
using SchoolRegister.Infrastructure.DTO;
using SchoolRegister.Core.Domain;
using System.Threading.Tasks;
using AutoMapper;

namespace SchoolRegister.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IEncrypter _encrypter;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        public UserService(IEncrypter encrypter, IMapper mapper, IUserRepository userRepository)
        {
            _encrypter = encrypter;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

/*             return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName
            }; */
            return _mapper.Map<UserDto>(user);
        }
        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user == null)
            {
                throw new Exception("Invalid credentials");
            }

            var hash = _encrypter.GetHash(password, user.Salt);
            if(user.Password == hash)
            {
                return;
            }
            throw new Exception("Invalid credentials");
        }

        public async Task RegisterAsync(string email, string username,string role, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password,salt);
            user = new User(Guid.NewGuid(),email,username,"student", hash, salt);
            await _userRepository.AddAsync(user);
        }
    }
}