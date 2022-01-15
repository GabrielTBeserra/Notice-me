using NOTICE_ME_COMMON.Configurations.Http;

namespace NOTICE_ME_COMMON.Helpers.HttpContext
{
    public static class HttpHelper
    {
        public static string LoggedUser
        {
            get { return HttpContextGetter.ContextAcessor.HttpContext?.User.Identity.Name; }
        }
    }
}
