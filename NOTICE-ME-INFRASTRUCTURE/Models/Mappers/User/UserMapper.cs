using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTICE_ME_DOMAIN.Entities.User;

namespace NOTICE_ME_INFRASTRUCTURE.Models.Mappers.User
{
    public class UserMapper : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.Notices)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
