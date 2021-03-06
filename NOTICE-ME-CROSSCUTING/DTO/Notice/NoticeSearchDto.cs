using System;
using System.Collections.Generic;

namespace NOTICE_ME_CROSSCUTING.DTO.Notice
{
    public class NoticeSearchDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string PublisherName { get; set; }
        public int Status { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}
