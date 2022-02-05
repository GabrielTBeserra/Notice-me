using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOTICE_ME_DOMAIN.Entities.Notice
{
    [Table("NoticeCategories")]
    public class NoticeCategoriesEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("notice_id")]
        public Guid NoticeId { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        public virtual CategoriesEntity Category { get; set; }
        public virtual NoticeEntity Notice { get; set; }
    }
}
