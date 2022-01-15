using NOTICE_ME_DOMAIN.Entities.Notice;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOTICE_ME_DOMAIN.Entities.User
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("email")]
        public string Email { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("password")]
        public string Password { get; set; }
        public ICollection<NoticeEntity> Notices { get; set; }
    }
}
