using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NOTICE_ME_COMMON.Exceptions;
using NOTICE_ME_COMMON.Helpers.StringContext;
using NOTICE_ME_CROSSCUTING.DTO.Notice;
using NOTICE_ME_CROSSCUTING.DTO.User;
using NOTICE_ME_CROSSCUTING.Enum.Notice;
using NOTICE_ME_DOMAIN.Entities.Notice;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Notice.Interfaces;
using NOTICE_ME_SERVICE.ApplicationService.Config;
using NOTICE_ME_SERVICE.ApplicationService.Notice.Interfaces;

namespace NOTICE_ME_SERVICE.ApplicationService.Notice
{
    public class NoticeApplicationService : BaseApplicationService, INoticeApplicationService
    {
        private readonly INoticeUnitOfWork _uow;

        public NoticeApplicationService(IBaseUnitOfWork unitOfWork, INoticeUnitOfWork noticeUnitOfWork) : base(
            unitOfWork)
        {
            _uow = noticeUnitOfWork;
        }

        public async Task Post(NoticePostDto dto, CancellationToken cto = default)
        {
            cto.ThrowIfCancellationRequested();

            var exitsTitle = _uow.NoticeRepository.GetUntracked().Any(x => x.SanetizedTitle == dto.Title.Sanatize());

            if (exitsTitle) throw new DomainException("Notice already exists");

            var notice = new NoticeEntity
            {
                User = await GetLoggedUserTracked(),
                Content = dto.Content,
                Title = dto.Title,
                SanetizedTitle = dto.Title.Sanatize(),
                Id = Guid.NewGuid(),
                PublicationDate = DateTime.Now,
                Status = (int) NoticeStatusEnum.Waiting
            };

            await _uow.NoticeRepository.AddAsync(notice);
            await _uow.CommitAsync();
        }

        public async Task<IEnumerable<NoticeSearchDto>> Search(string query, CancellationToken cto = default)
        {
            cto.ThrowIfCancellationRequested();

            var noticesList = _uow.NoticeRepository.GetUntracked()
                .Include(x => x.User)
                .Where(x => x.SanetizedTitle.ToLower().Contains(query.ToLower()));

            var dtoList = await noticesList.Select(x => new NoticeSearchDto
            {
                Id = x.Id.ToString(),
                Title = x.Title,
                PublicationDate = x.PublicationDate,
                PublisherName = x.User.Name,
                Categories = x.NoticeCategories.Select(x => x.Category.Name).ToList()
            }).ToListAsync(cto);

            return dtoList;
        }

        public async Task<IEnumerable<NoticeSearchDto>> MyNotices(CancellationToken cto = default)
        {
            cto.ThrowIfCancellationRequested();

            var user = await GetLoggedUserUntracked();

            var noticesList = _uow.NoticeRepository.GetUntracked()
                .Include(x => x.User)
                .Where(x => x.User.Id == user.Id);

            var dtoList = await noticesList.Select(x => new NoticeSearchDto
            {
                Id = x.Id.ToString(),
                Title = x.Title,
                PublicationDate = x.PublicationDate,
                PublisherName = x.User.Name,
                Status = x.Status
            }).ToListAsync(cto);

            return dtoList;
        }

        public async Task<IEnumerable<NoticeFeedDto>> GetFeed(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var noticesList = _uow.NoticeRepository.GetUntracked()
                .Include(x => x.User)
                .Where(x => x.Status == (int) NoticeStatusEnum.Approved)
                .OrderByDescending(x => x.PublicationDate)
                .Take(10);

            var dtoList = await noticesList.Select(x => new NoticeFeedDto
            {
                Id = x.Id.ToString(),
                Title = x.Title,
                PublicationDate = x.PublicationDate,
                PublisherName = x.User.Name
            }).ToListAsync(ct);

            return dtoList;
        }

        public async Task<IEnumerable<TopUserFeedDto>> GetTopUsers(CancellationToken ct)
        {
            return null;
        }

        public async Task ChangeStatus(NoticeChangeStatusDto changeStatus, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var notice = await _uow.NoticeRepository.GetTracked()
                .FirstOrDefaultAsync(x => x.Id == Guid.Parse(changeStatus.NoticeId) , ct);
            notice.Status = changeStatus.Status;

            await _uow.CommitAsync();
        }

        public async Task<IEnumerable<NoticeWaitingAvaliationDto>> GetNoticeWaitingAvaliationDto(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var listFromDb = _uow.NoticeRepository.GetUntracked()
                .Where(x => x.Status == (int) NoticeStatusEnum.Waiting);

            var response = await listFromDb.Select(x => new NoticeWaitingAvaliationDto
            {
                Title = x.Title,
                NoticeId = x.Id.ToString()
            }).ToListAsync(ct);

            return response;
        }
    }
}