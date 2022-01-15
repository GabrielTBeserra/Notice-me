using Microsoft.EntityFrameworkCore;
using NOTICE_ME_DOMAIN.Entities.Notice;
using NOTICE_ME_DOMAIN.Entities.User;

namespace NOTICE_ME_INFRASTRUCTURE.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<NoticeEntity> Notices { get; set; }
    }
}
