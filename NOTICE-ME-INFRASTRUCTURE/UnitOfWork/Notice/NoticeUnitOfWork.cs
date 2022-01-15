using NOTICE_ME_INFRASTRUCTURE.Models;
using NOTICE_ME_INFRASTRUCTURE.Repositories.Notice.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Config;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Notice.Interfaces;

namespace NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Notice
{
    public class NoticeUnitOfWork : BaseConfigUnitOfWork, INoticeUnitOfWork
    {
        public NoticeUnitOfWork(ApplicationDbContext applicationDbContext, INoticeRepository noticeRepository) : base(applicationDbContext)
        {
            NoticeRepository = noticeRepository;
        }

        public INoticeRepository NoticeRepository { get; }
    }
}
