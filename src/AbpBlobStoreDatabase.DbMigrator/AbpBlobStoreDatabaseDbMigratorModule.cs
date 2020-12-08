using AbpBlobStoreDatabase.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpBlobStoreDatabase.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpBlobStoreDatabaseEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpBlobStoreDatabaseApplicationContractsModule)
        )]
    public class AbpBlobStoreDatabaseDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
