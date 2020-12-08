using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlobStoringDatabase.Data;
using Volo.Abp.DependencyInjection;

namespace BlobStoringDatabase.EntityFrameworkCore
{
    public class EntityFrameworkCoreBlobStoringDatabaseDbSchemaMigrator
        : IBlobStoringDatabaseDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreBlobStoringDatabaseDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the BlobStoringDatabaseMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<BlobStoringDatabaseMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}