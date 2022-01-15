using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NOTICE_ME_INFRASTRUCTURE.Repositories.Notice;
using NOTICE_ME_INFRASTRUCTURE.Repositories.Notice.Interfaces;
using NOTICE_ME_INFRASTRUCTURE.Repositories.User;
using NOTICE_ME_INFRASTRUCTURE.Repositories.User.Interfaces;

namespace NOTICE_ME_SERVICE.DependencyInjection.RepositoryInjection
{
    public static class ConfigureBindingsRepository
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INoticeRepository, NoticeRepository>();
        }

    }
}
