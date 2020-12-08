using Volo.Abp.Bundling;

namespace AbpBlobStoreDatabase.Blazor
{
    public class AbpBlobStoreDatabaseBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css");
        }
    }
}
