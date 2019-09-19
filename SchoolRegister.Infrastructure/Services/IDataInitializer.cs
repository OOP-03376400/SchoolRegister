using System.Threading.Tasks;

namespace SchoolRegister.Infrastructure.Services
{
    public interface IDataInitializer : IService
    {
         Task SeedAsync();
    }
}