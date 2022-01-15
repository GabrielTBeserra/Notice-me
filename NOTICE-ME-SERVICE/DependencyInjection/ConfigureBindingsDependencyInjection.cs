using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NOTICE_ME_SERVICE.DependencyInjection.ApplicationServiceInjection;
using NOTICE_ME_SERVICE.DependencyInjection.RepositoryInjection;
using NOTICE_ME_SERVICE.DependencyInjection.UnitOfWorkInjection;

namespace NOTICE_ME_SERVICE.DependencyInjection
{
    public static class ConfigureBindingsDependencyInjection
    {

        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureBindingsApplicationService.RegisterBindings(services, configuration);
            ConfigureBindingsRepository.RegisterBindings(services, configuration);
            ConfigureBindinsUnifOfWorks.RegisterBindings(services, configuration);
        }
    }
}