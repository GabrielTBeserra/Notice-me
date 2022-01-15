using Microsoft.EntityFrameworkCore;
using NOTICE_ME_INFRASTRUCTURE.Models;
using NOTICE_ME_INFRASTRUCTURE.Repositories.Config.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace NOTICE_ME_INFRASTRUCTURE.Repositories.Config
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddAsync(T obj)
        {
            await _applicationDbContext.Set<T>().AddAsync(obj);
        }

        public void Delete(T obj)
        {
            _applicationDbContext.Set<T>().Remove(obj);
        }

        public void Edit(T obj)
        {
            _applicationDbContext.Set<T>().Update(obj);
        }

        public virtual IQueryable<T> GetTracked()
        {
            return _applicationDbContext.Set<T>();
        }

        public virtual IQueryable<T> GetUntracked()
        {
            return _applicationDbContext.Set<T>().AsNoTracking();
        }
    }
}
