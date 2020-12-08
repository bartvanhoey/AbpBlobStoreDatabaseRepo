using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpBlobStoreDatabase.Data
{
    /* This is used if database provider does't define
     * IAbpBlobStoreDatabaseDbSchemaMigrator implementation.
     */
    public class NullAbpBlobStoreDatabaseDbSchemaMigrator : IAbpBlobStoreDatabaseDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}