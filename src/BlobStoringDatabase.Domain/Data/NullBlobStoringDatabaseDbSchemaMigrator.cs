using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BlobStoringDatabase.Data
{
    /* This is used if database provider does't define
     * IBlobStoringDatabaseDbSchemaMigrator implementation.
     */
    public class NullBlobStoringDatabaseDbSchemaMigrator : IBlobStoringDatabaseDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}