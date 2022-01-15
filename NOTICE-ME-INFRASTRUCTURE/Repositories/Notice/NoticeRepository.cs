using NOTICE_ME_DOMAIN.Entities.Notice;
using NOTICE_ME_INFRASTRUCTURE.Models;
using NOTICE_ME_INFRASTRUCTURE.Repositories.Config;
using NOTICE_ME_INFRASTRUCTURE.Repositories.Notice.Interfaces;

namespace NOTICE_ME_INFRASTRUCTURE.Repositories.Notice
{
    public class NoticeRepository : GenericRepository<NoticeEntity>, INoticeRepository
    {
        public NoticeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
