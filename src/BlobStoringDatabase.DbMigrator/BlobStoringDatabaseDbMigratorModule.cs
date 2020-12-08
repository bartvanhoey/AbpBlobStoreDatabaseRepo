using BlobStoringDatabase.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace BlobStoringDatabase.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BlobStoringDatabaseEntityFrameworkCoreDbMigrationsModule),
        typeof(BlobStoringDatabaseApplicationContractsModule)
        )]
    public class BlobStoringDatabaseDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
