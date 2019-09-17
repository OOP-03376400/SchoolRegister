using System.Threading.Tasks;

namespace SchoolRegister.Infrastructure.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}