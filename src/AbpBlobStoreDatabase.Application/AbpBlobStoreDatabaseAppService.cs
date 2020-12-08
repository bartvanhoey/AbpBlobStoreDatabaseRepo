using System;
using System.Collections.Generic;
using System.Text;
using AbpBlobStoreDatabase.Localization;
using Volo.Abp.Application.Services;

namespace AbpBlobStoreDatabase
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpBlobStoreDatabaseAppService : ApplicationService
    {
        protected AbpBlobStoreDatabaseAppService()
        {
            LocalizationResource = typeof(AbpBlobStoreDatabaseResource);
        }
    }
}
