using BlobStoringDatabase.Localization;
using Volo.Abp.AspNetCore.Components;

namespace BlobStoringDatabase.Blazor
{
    public abstract class BlobStoringDatabaseComponentBase : AbpComponentBase
    {
        protected BlobStoringDatabaseComponentBase()
        {
            LocalizationResource = typeof(BlobStoringDatabaseResource);
        }
    }
}
