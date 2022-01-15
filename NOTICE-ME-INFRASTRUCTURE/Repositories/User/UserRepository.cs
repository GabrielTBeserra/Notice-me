using NOTICE_ME_DOMAIN.Entities.User;
using NOTICE_ME_INFRASTRUCTURE.Models;
using NOTICE_ME_INFRASTRUCTURE.Repositories.Config;
using NOTICE_ME_INFRASTRUCTURE.Repositories.User.Interfaces;

namespace NOTICE_ME_INFRASTRUCTURE.Repositories.User
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
