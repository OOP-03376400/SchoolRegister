namespace SchoolRegister.Infrastructure.Services
{
    public interface IHandlerTaskRunner
    {
        IHandlerTask Run(Func<Task> runAsync);         
    }
}