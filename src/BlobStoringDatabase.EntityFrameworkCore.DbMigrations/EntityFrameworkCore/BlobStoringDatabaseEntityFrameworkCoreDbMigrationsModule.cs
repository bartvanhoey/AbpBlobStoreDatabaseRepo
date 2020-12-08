using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace BlobStoringDatabase.EntityFrameworkCore
{
    [DependsOn(
        typeof(BlobStoringDatabaseEntityFrameworkCoreModule)
        )]
    public class BlobStoringDatabaseEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BlobStoringDatabaseMigrationsDbContext>();
        }
    }
}
