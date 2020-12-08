using Volo.Abp.Modularity;

namespace BlobStoringDatabase
{
    [DependsOn(
        typeof(BlobStoringDatabaseApplicationModule),
        typeof(BlobStoringDatabaseDomainTestModule)
        )]
    public class BlobStoringDatabaseApplicationTestModule : AbpModule
    {

    }
}