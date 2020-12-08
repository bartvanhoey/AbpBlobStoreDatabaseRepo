using Volo.Abp.Modularity;

namespace AbpBlobStoreDatabase
{
    [DependsOn(
        typeof(AbpBlobStoreDatabaseApplicationModule),
        typeof(AbpBlobStoreDatabaseDomainTestModule)
        )]
    public class AbpBlobStoreDatabaseApplicationTestModule : AbpModule
    {

    }
}