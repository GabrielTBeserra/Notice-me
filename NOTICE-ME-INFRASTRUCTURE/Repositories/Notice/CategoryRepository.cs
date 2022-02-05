using NOTICE_ME_DOMAIN.Entities.Notice;
using NOTICE_ME_INFRASTRUCTURE.Models;
using NOTICE_ME_INFRASTRUCTURE.Repositories.Config;
using NOTICE_ME_INFRASTRUCTURE.Repositories.Notice.Interfaces;

namespace NOTICE_ME_INFRASTRUCTURE.Repositories.Notice
{
    public class CategoryRepository : GenericRepository<CategoriesEntity>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
