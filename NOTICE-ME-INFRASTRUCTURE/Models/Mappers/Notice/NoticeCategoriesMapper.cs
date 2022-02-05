using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTICE_ME_DOMAIN.Entities.Notice;

namespace NOTICE_ME_INFRASTRUCTURE.Models.Mappers.Notice
{
    public class NoticeCategoriesMapper : IEntityTypeConfiguration<NoticeCategoriesEntity>
    {
        public void Configure(EntityTypeBuilder<NoticeCategoriesEntity> builder)
        {
            builder.HasOne(x => x.Category)
                .WithMany(x => x.NoticeCategory)
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Notice)
                .WithMany(x => x.NoticeCategories)
                .HasForeignKey(x => x.NoticeId);
        }
    }
}

