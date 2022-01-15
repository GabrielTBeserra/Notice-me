using Microsoft.AspNetCore.Http;

namespace NOTICE_ME_COMMON.Configurations.Http
{
    public static class HttpContextGetter
    {
        public static IHttpContextAccessor ContextAcessor;

        public static void Configure(IHttpContextAccessor acessor)
        {
            ContextAcessor = acessor;
        }
    }
}
