using NOTICE_ME_INFRASTRUCTURE.Models;
using NOTICE_ME_INFRASTRUCTURE.Repositories.User.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Config;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.User.Interfaces;

namespace NOTICE_ME_INFRASTRUCTURE.UnitOfWork.User
{
    public class AuthUnitOfWork : BaseConfigUnitOfWork, IAuthUnitOfWork
    {
        public AuthUnitOfWork(ApplicationDbContext applicationDbContext, IUserRepository userRepository) : base(applicationDbContext)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }

    }
}
