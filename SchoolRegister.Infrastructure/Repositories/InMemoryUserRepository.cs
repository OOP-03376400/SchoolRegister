using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
            => _users.Single(x => x.Id == id);

        public User Get(string email)
            => _users.Single(x => x.Email == email.ToLowerInvariant());

        public IEnumerable<User> GetAll()
            => _users;

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
        }
    }
}