using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace BlobStoringDatabase.EntityFrameworkCore
{
    public static class BlobStoringDatabaseDbContextModelCreatingExtensions
    {
        public static void ConfigureBlobStoringDatabase(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(BlobStoringDatabaseConsts.DbTablePrefix + "YourEntities", BlobStoringDatabaseConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}