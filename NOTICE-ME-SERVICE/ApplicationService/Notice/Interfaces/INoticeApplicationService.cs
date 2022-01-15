using NOTICE_ME_CROSSCUTING.DTO.Notice;
using NOTICE_ME_SERVICE.ApplicationService.Config.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NOTICE_ME_SERVICE.ApplicationService.Notice.Interfaces
{
    public interface INoticeApplicationService: IBaseApplicationService
    {
        Task Post(NoticePostDto dto);
        Task<IEnumerable<NoticeSearchDto>> Search(string query);
        Task<IEnumerable<NoticeSearchDto>> MyNotices();
    }
}
