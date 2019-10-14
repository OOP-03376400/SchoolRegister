using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolRegister.Core.Domain;

namespace SchoolRegister.Core.Repositories
{
    public interface IGroupRepository
    {
        Task<Group> GetAsync(Guid id);  
        Task<IEnumerable<Group>> GetAllAsync(YearNumber yearNumber); //TODO + school Id, in case where is many schools
        Task AddAsync(Group group);
        Task UpdateAsync(Group group);
        Task RemoveAsync(Guid id);
    }
}