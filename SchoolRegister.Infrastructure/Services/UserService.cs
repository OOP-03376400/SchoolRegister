using System;
using SchoolRegister.Core.Repositories;
using SchoolRegister.Infrastructure.DTO;
using SchoolRegister.Core.Domain;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using SchoolRegister.Infrastructure.Exceptions;

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
        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<User>,IEnumerable<UserDto>>(users);
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
                throw new ServiceException(SchoolRegister.Infrastructure.Exceptions.ErrorCodes.InvalidEmail,
                "Invalid credentials");
            }

            var hash = _encrypter.GetHash(password, user.Salt);
            if(user.Password == hash)
            {
                return;
            }
            throw new ServiceException(SchoolRegister.Infrastructure.Exceptions.ErrorCodes.InvalidCredentials,
            "Invalid credentials");
        }

        public async Task RegisterAsync(string email, string username,string role, string password)
        {

            var user = await _userRepository.GetAsync(email);

            if(user != null)
            {
                throw new ServiceException(SchoolRegister.Infrastructure.Exceptions.ErrorCodes.EmailInUse,
                ($"User with email: '{email}' already exists."));
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password,salt);
            user = new User(Guid.NewGuid(),email,username,role, hash, salt);
            await _userRepository.AddAsync(user);
        }
    }
}