using System;
using System.Threading.Tasks;
using SchoolRegister.Core.Domain;
using SchoolRegister.Core.Repositories;
using SchoolRegister.Infrastructure.Exceptions;

namespace SchoolRegister.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, Guid userId)
        {
            var user = await repository.GetAsync(userId);
            if(user == null)
            {
                throw new ServiceException(SchoolRegister.Infrastructure.Exceptions.ErrorCodes.UserNotFound, $"User with id: '{userId}' was not found.");
            }

            return user;            
        }   
    }
}