using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpBlobStoreDatabase.Data;
using Volo.Abp.DependencyInjection;

namespace AbpBlobStoreDatabase.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpBlobStoreDatabaseDbSchemaMigrator
        : IAbpBlobStoreDatabaseDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpBlobStoreDatabaseDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpBlobStoreDatabaseMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpBlobStoreDatabaseMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}