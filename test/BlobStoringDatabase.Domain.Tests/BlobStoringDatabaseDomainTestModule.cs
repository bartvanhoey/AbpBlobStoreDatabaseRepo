using BlobStoringDatabase.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BlobStoringDatabase
{
    [DependsOn(
        typeof(BlobStoringDatabaseEntityFrameworkCoreTestModule)
        )]
    public class BlobStoringDatabaseDomainTestModule : AbpModule
    {

    }
}