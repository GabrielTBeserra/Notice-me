using NOTICE_ME_DOMAIN.Entities.Notice;
using NOTICE_ME_INFRASTRUCTURE.Repositories.Config.Interfaces;

namespace NOTICE_ME_INFRASTRUCTURE.Repositories.Notice.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<CategoriesEntity>
    {
    }
}
