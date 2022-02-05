using NOTICE_ME_INFRASTRUCTURE.Repositories.Notice.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;

namespace NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Notice.Interfaces
{
    public interface ICategoryUnitOfWork : IBaseUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
    }
}
