using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpBlobStoreDatabase
{
    [Dependency(ReplaceServices = true)]
    public class AbpBlobStoreDatabaseBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpBlobStoreDatabase";
    }
}
