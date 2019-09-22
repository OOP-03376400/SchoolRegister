using System;
using System.Threading.Tasks;

namespace SchoolRegister.Infrastructure.Services
{
    public interface IHandler : IService
    {
        IHandlerTask Run(Func<Task> runAsync);
        IHandlerTaskRunner Validate(Func<Task> validateAsync);
        Task ExecuteAllAsync();
    }
}