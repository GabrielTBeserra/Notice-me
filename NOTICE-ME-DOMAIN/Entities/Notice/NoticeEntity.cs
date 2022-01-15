using NOTICE_ME_DOMAIN.Entities.User;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOTICE_ME_DOMAIN.Entities.Notice
{
    [Table("Notice")]
    public class NoticeEntity
    {
        [Key]
        [Column("notice_id")]
        public Guid Id { get; set; }

        [Column("title")]
        [Required]
        public string Title { get; set; }

        [Column("sanetized_title")]
        [Required]
        public string SanetizedTitle { get; set; }

        [Column("content")]
        [Required]
        public string Content { get; set; }

        [Column("user_owner_id")]
        [Required]
        public int UserId { get; set; }

        [Column("pubblication_date")]
        [Required]
        public DateTime PublicationDate { get; set; }

        public UserEntity User { get; set; }
    }
}
