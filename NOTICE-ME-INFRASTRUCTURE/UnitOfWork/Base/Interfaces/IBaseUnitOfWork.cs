using NOTICE_ME_INFRASTRUCTURE.Repositories.User.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Config.Interfaces;

namespace NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Base.Interfaces
{
    public interface IBaseUnitOfWork : IBaseConfigUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
