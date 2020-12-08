using BlobStoringDatabase.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BlobStoringDatabase.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BlobStoringDatabaseController : AbpController
    {
        protected BlobStoringDatabaseController()
        {
            LocalizationResource = typeof(BlobStoringDatabaseResource);
        }
    }
}