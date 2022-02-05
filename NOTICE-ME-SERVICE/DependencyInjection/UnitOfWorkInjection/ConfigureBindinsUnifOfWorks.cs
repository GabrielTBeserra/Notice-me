using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Base;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Config;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Config.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Notice;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Notice.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.User;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.User.Interfaces;

namespace NOTICE_ME_SERVICE.DependencyInjection.UnitOfWorkInjection
{
    public static class ConfigureBindinsUnifOfWorks
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthUnitOfWork, AuthUnitOfWork>();
            services.AddScoped<INoticeUnitOfWork, NoticeUnitOfWork>();
            services.AddScoped<IBaseConfigUnitOfWork, BaseConfigUnitOfWork>();
            services.AddScoped<IBaseUnitOfWork, BaseUnitOfWork>();
            services.AddScoped<ICategoryUnitOfWork , CategoryUnitOfWork>();
        }
    }
}
