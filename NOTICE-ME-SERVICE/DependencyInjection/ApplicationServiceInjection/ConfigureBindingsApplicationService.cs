using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NOTICE_ME_SERVICE.ApplicationService.Auth;
using NOTICE_ME_SERVICE.ApplicationService.Auth.Interfaces;
using NOTICE_ME_SERVICE.ApplicationService.Config;
using NOTICE_ME_SERVICE.ApplicationService.Config.Interfaces;
using NOTICE_ME_SERVICE.ApplicationService.Notice;
using NOTICE_ME_SERVICE.ApplicationService.Notice.Interfaces;

namespace NOTICE_ME_SERVICE.DependencyInjection.ApplicationServiceInjection
{
    public static class ConfigureBindingsApplicationService
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenApplicationService, TokenApplicationService>();
            services.AddScoped<IBaseApplicationService, BaseApplicationService>();

            #region AUTH
            services.AddScoped<IAuthApplicationService, AuthApplicationService>();
            #endregion

            #region NOTICE
            services.AddScoped<INoticeApplicationService, NoticeApplicationService>();
            #endregion
        }
    }
}
