using NOTICE_ME_DOMAIN.Entities.User;
using NOTICE_ME_INFRASTRUCTURE.Repositories.Config.Interfaces;

namespace NOTICE_ME_INFRASTRUCTURE.Repositories.User.Interfaces
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
    }
}
