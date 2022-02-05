using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTICE_ME_DOMAIN.Entities.Notice;

namespace NOTICE_ME_INFRASTRUCTURE.Models.Mappers.Notice
{
    public class NoticeMapper : IEntityTypeConfiguration<NoticeEntity>
    {
        public void Configure(EntityTypeBuilder<NoticeEntity> builder)
        {
            builder.HasIndex(x => x.Title).IsUnique();

            builder.Property(x => x.Id)
                   .HasColumnType("varchar(36)");

            builder.Property(x => x.PublicationDate)
                    .HasColumnType("DATETIME");

        }
    }
}
