using NOTICE_ME_INFRASTRUCTURE.Models;
using NOTICE_ME_INFRASTRUCTURE.Repositories.Notice.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.Repositories.User.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Config;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Notice.Interfaces;

namespace NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Notice
{
    public class CategoryUnitOfWork : BaseConfigUnitOfWork, ICategoryUnitOfWork
    {
        public CategoryUnitOfWork(ApplicationDbContext applicationDbContext, ICategoryRepository categoryRepository) : base(applicationDbContext)
        {
            CategoryRepository = categoryRepository;
        }

        public ICategoryRepository CategoryRepository { get; }
        public IUserRepository UserRepository { get; }
    }
}
