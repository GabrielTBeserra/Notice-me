using NOTICE_ME_INFRASTRUCTURE.Repositories.User.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Config.Interfaces;

namespace NOTICE_ME_INFRASTRUCTURE.UnitOfWork.User.Interfaces
{
    public interface IAuthUnitOfWork : IBaseConfigUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
