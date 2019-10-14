using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolRegister.Core.Domain;

namespace SchoolRegister.Core.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetAsync(Guid id);  
        Task<IEnumerable<Student>> GetAllAsync();
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task RemoveAsync(Guid id);
    }
}