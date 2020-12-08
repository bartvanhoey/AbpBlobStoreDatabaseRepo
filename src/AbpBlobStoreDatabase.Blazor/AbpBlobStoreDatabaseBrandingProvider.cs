using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpBlobStoreDatabase.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class AbpBlobStoreDatabaseBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpBlobStoreDatabase";
    }
}
