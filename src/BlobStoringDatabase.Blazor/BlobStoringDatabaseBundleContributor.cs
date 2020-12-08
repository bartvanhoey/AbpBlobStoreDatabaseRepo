using Volo.Abp.Bundling;

namespace BlobStoringDatabase.Blazor
{
    public class BlobStoringDatabaseBundleContributor : IBundleContributor
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
