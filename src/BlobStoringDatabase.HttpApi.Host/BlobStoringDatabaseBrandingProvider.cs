using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BlobStoringDatabase
{
    [Dependency(ReplaceServices = true)]
    public class BlobStoringDatabaseBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "BlobStoringDatabase";
    }
}
