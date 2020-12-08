using AbpBlobStoreDatabase.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpBlobStoreDatabase
{
    [DependsOn(
        typeof(AbpBlobStoreDatabaseEntityFrameworkCoreTestModule)
        )]
    public class AbpBlobStoreDatabaseDomainTestModule : AbpModule
    {

    }
}