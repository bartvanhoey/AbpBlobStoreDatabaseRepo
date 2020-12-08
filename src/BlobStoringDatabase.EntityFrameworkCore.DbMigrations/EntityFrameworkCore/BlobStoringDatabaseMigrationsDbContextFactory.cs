using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BlobStoringDatabase.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class BlobStoringDatabaseMigrationsDbContextFactory : IDesignTimeDbContextFactory<BlobStoringDatabaseMigrationsDbContext>
    {
        public BlobStoringDatabaseMigrationsDbContext CreateDbContext(string[] args)
        {
            BlobStoringDatabaseEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<BlobStoringDatabaseMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new BlobStoringDatabaseMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BlobStoringDatabase.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
