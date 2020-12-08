using AbpBlobStoreDatabase.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpBlobStoreDatabase.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpBlobStoreDatabaseController : AbpController
    {
        protected AbpBlobStoreDatabaseController()
        {
            LocalizationResource = typeof(AbpBlobStoreDatabaseResource);
        }
    }
}