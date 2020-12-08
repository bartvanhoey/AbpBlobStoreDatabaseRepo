using System;
using System.Collections.Generic;
using System.Text;
using BlobStoringDatabase.Localization;
using Volo.Abp.Application.Services;

namespace BlobStoringDatabase
{
    /* Inherit your application services from this class.
     */
    public abstract class BlobStoringDatabaseAppService : ApplicationService
    {
        protected BlobStoringDatabaseAppService()
        {
            LocalizationResource = typeof(BlobStoringDatabaseResource);
        }
    }
}
