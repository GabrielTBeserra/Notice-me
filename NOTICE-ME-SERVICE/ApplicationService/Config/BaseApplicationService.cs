using Microsoft.EntityFrameworkCore;
using NOTICE_ME_COMMON.Exceptions;
using NOTICE_ME_COMMON.Helpers.HttpContext;
using NOTICE_ME_DOMAIN.Entities.User;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using NOTICE_ME_SERVICE.ApplicationService.Config.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace NOTICE_ME_SERVICE.ApplicationService.Config
{
    public class BaseApplicationService : IBaseApplicationService
    {
        protected readonly IBaseUnitOfWork BaseUnitOfWork;

        public BaseApplicationService(IBaseUnitOfWork unitOfWork)
        {
            BaseUnitOfWork = unitOfWork;
        }

        public async Task<UserEntity> GetLoggedUserTracked()
        {
            var loggedUserName = HttpHelper.LoggedUser;
            var user = await BaseUnitOfWork.UserRepository.GetTracked().Where(x => x.Email == loggedUserName).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new DomainException("User not found");
            }

            return user;
        }


        public async Task<UserEntity> GetLoggedUserUntracked()
        {
            var loggedUserName = HttpHelper.LoggedUser;
            var user = await BaseUnitOfWork.UserRepository.GetTracked().Where(x => x.Email == loggedUserName).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new DomainException("User not found");
            }

            return user;
        }


    }
}
