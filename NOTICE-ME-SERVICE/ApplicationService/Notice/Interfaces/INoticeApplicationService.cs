using NOTICE_ME_CROSSCUTING.DTO.Notice;
using NOTICE_ME_CROSSCUTING.DTO.User;
using NOTICE_ME_SERVICE.ApplicationService.Config.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NOTICE_ME_SERVICE.ApplicationService.Notice.Interfaces
{
    public interface INoticeApplicationService : IBaseApplicationService
    {
        Task Post(NoticePostDto dto, CancellationToken cto);
        Task<IEnumerable<NoticeSearchDto>> Search(string query, CancellationToken ct);
        Task<IEnumerable<NoticeSearchDto>> MyNotices(CancellationToken ct);
        Task<IEnumerable<NoticeFeedDto>> GetFeed(CancellationToken ct);
        Task<IEnumerable<TopUserFeedDto>> GetTopUsers(CancellationToken ct);
        Task ChangeStatus(NoticeChangeStatusDto changeStatus, CancellationToken ct);
        Task<IEnumerable<NoticeWaitingAvaliationDto>> GetNoticeWaitingAvaliationDto(CancellationToken ct);
    }
}
