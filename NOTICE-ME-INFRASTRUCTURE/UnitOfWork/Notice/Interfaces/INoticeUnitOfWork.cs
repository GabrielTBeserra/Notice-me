using NOTICE_ME_INFRASTRUCTURE.Repositories.Notice.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Config.Interfaces;

namespace NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Notice.Interfaces
{
    public interface INoticeUnitOfWork : IBaseConfigUnitOfWork
    {
        INoticeRepository NoticeRepository { get; }
    }
}
