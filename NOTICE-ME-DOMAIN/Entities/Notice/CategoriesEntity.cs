using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOTICE_ME_DOMAIN.Entities.Notice
{
    [Table("Categories")]
    public class CategoriesEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Column("tag")]
        [Required]
        public string TAG { get; set; }
        public virtual ICollection<NoticeCategoriesEntity> NoticeCategory { get; set; }
    }
}
