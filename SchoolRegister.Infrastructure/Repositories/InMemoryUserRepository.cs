using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolRegister.Core.Domain;
using SchoolRegister.Core.Repositories;

namespace SchoolRegister.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User(Guid.NewGuid(),"user1@email.com", "user1","admin","secret", "salt"),
            new User(Guid.NewGuid(),"user2@email.com", "user2","teacher","secret", "salt"),
            new User(Guid.NewGuid(),"user3@email.com", "user3","student","secret", "salt")
        };

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.Single(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.Single(x => x.Email == email.ToLowerInvariant()));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}