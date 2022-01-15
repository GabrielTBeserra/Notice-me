using NOTICE_ME_DOMAIN.Entities.User;

namespace NOTICE_ME_SERVICE.ApplicationService.Config.Interfaces
{
    public interface ITokenApplicationService
    {
        string GenerateToken(UserEntity user);
    }
}
