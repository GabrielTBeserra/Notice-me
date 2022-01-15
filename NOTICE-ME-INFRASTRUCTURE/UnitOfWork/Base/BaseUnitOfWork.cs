using NOTICE_ME_INFRASTRUCTURE.Models;
using NOTICE_ME_INFRASTRUCTURE.Repositories.User.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Config;

namespace NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Base
{
    public class BaseUnitOfWork : BaseConfigUnitOfWork, IBaseUnitOfWork
    {
        public BaseUnitOfWork(ApplicationDbContext applicationDbContext, IUserRepository userRepository) : base(applicationDbContext)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }
    }
}
