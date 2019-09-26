using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Core.Domain;
using SchoolRegister.Core.Repositories;
using SchoolRegister.Infrastructure.EF;

namespace SchoolRegister.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository, ISqlRepository
    {
        private readonly SchoolRegisterContext _context;
        public UserRepository(SchoolRegisterContext context)
        {
            _context = context;
        }
        public async Task<User> GetAsync(Guid id) => await _context.Users.SingleOrDefaultAsync(x => x.Id == id);


        public async Task<User> GetAsync(string email) => await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
        public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.ToListAsync();
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

    }
}