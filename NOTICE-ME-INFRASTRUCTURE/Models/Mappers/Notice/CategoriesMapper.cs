using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTICE_ME_DOMAIN.Entities.Notice;

namespace NOTICE_ME_INFRASTRUCTURE.Models.Mappers.Notice
{
    public class CategoriesMapper : IEntityTypeConfiguration<CategoriesEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriesEntity> builder)
        {

        }
    }
}
