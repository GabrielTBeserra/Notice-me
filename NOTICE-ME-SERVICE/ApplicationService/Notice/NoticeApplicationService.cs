using Microsoft.EntityFrameworkCore;
using NOTICE_ME_COMMON.Helpers.StringContext;
using NOTICE_ME_CROSSCUTING.DTO.Notice;
using NOTICE_ME_DOMAIN.Entities.Notice;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Notice.Interfaces;
using NOTICE_ME_SERVICE.ApplicationService.Config;
using NOTICE_ME_SERVICE.ApplicationService.Notice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOTICE_ME_SERVICE.ApplicationService.Notice
{
    public class NoticeApplicationService : BaseApplicationService, INoticeApplicationService
    {
        private readonly INoticeUnitOfWork _uow;
        public NoticeApplicationService(IBaseUnitOfWork unitOfWork, INoticeUnitOfWork noticeUnitOfWork) : base(unitOfWork)
        {
            _uow = noticeUnitOfWork;
        }

        public async Task Post(NoticePostDto dto)
        {
            var notice = new NoticeEntity
            {
                User = await GetLoggedUserTracked(),
                Content = dto.Content,
                Title = dto.Title,
                SanetizedTitle = dto.Title.Sanatize(),
                Id = Guid.NewGuid(),
                PublicationDate = DateTime.Now
            };

            await _uow.NoticeRepository.AddAsync(notice);
            await _uow.CommitAsync();
        }

        public async Task<IEnumerable<NoticeSearchDto>> Search(string query)
        {
            var noticesList = _uow.NoticeRepository.GetUntracked()
                .Include(x => x.User)
                .Where(x => x.SanetizedTitle.ToLower().Contains(query.ToLower()));

            var dtoList = await (noticesList.Select(x => new NoticeSearchDto
            {
                Title = x.Title,
                PublicationDate = x.PublicationDate,
                PublisherName = x.User.Name
            }).ToListAsync());

            return dtoList;
        }
    }
}
