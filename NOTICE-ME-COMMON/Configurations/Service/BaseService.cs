using NOTICE_ME_COMMON.Helpers.HttpContext;

namespace NOTICE_ME_COMMON.Configurations.Service
{
    public abstract class BaseService
    {
        protected string LoggedUser
        {
            get { return HttpHelper.LoggedUser; }
        }
    }
}
