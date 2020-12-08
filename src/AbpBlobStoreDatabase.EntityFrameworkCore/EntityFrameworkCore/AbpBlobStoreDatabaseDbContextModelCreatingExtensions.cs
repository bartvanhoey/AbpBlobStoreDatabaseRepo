using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AbpBlobStoreDatabase.EntityFrameworkCore
{
    public static class AbpBlobStoreDatabaseDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpBlobStoreDatabase(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpBlobStoreDatabaseConsts.DbTablePrefix + "YourEntities", AbpBlobStoreDatabaseConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}