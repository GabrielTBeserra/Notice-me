using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NOTICE_ME_INFRASTRUCTURE.Models;

namespace NOTICE_ME_SERVICE.DependencyInjection
{
    public static class ConfigureBindingsDatabaseContext
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("mysqllocalhost");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(connectionString, providerOptions => providerOptions.EnableRetryOnFailure());
            });

        }
    }
}