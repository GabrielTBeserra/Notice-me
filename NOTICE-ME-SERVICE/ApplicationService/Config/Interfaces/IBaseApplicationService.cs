using NOTICE_ME_DOMAIN.Entities.User;
using System.Threading.Tasks;

namespace NOTICE_ME_SERVICE.ApplicationService.Config.Interfaces
{
    public interface IBaseApplicationService
    {
        Task<UserEntity> GetLoggedUserUntracked();
        Task<UserEntity> GetLoggedUserTracked();
    }
}
