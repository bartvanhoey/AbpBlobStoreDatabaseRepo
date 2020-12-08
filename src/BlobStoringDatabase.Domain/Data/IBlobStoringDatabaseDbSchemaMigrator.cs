using System.Threading.Tasks;

namespace BlobStoringDatabase.Data
{
    public interface IBlobStoringDatabaseDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
