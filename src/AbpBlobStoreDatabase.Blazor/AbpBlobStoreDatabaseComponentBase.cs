using AbpBlobStoreDatabase.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpBlobStoreDatabase.Blazor
{
    public abstract class AbpBlobStoreDatabaseComponentBase : AbpComponentBase
    {
        protected AbpBlobStoreDatabaseComponentBase()
        {
            LocalizationResource = typeof(AbpBlobStoreDatabaseResource);
        }
    }
}
