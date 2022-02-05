using NOTICE_ME_DOMAIN.Entities.Notice;
using System.Collections.Generic;

namespace NOTICE_ME_CROSSCUTING.DTO.User
{
    public class TopUserFeedDto
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public List<NoticeEntity> Entities { get; set; }
    }
}
