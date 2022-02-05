using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Notice.Interfaces;
using NOTICE_ME_SERVICE.ApplicationService.Config;
using NOTICE_ME_SERVICE.ApplicationService.Notice.Interfaces;

namespace NOTICE_ME_SERVICE.ApplicationService.Notice
{
    public class CategoryApplicationService : BaseApplicationService, ICategoryApplicationService
    {
        private readonly ICategoryUnitOfWork _uow;

        public CategoryApplicationService(IBaseUnitOfWork unitOfWork, ICategoryUnitOfWork noticeUnitOfWork) : base(
            unitOfWork)
        {
            _uow = noticeUnitOfWork;
        }
    }
}
