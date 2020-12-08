using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpBlobStoreDatabase.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpBlobStoreDatabaseEntityFrameworkCoreModule)
        )]
    public class AbpBlobStoreDatabaseEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpBlobStoreDatabaseMigrationsDbContext>();
        }
    }
}
