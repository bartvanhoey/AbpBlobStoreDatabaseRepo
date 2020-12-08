using System.Threading.Tasks;

namespace AbpBlobStoreDatabase.Data
{
    public interface IAbpBlobStoreDatabaseDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
