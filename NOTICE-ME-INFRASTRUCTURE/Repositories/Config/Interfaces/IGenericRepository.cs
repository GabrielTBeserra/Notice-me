using System.Linq;
using System.Threading.Tasks;

namespace NOTICE_ME_INFRASTRUCTURE.Repositories.Config.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T obj);
        void Edit(T obj);
        void Delete(T obj);
        IQueryable<T> GetTracked();
        IQueryable<T> GetUntracked();
    }
}
