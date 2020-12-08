using Volo.Abp.Settings;

namespace BlobStoringDatabase.Settings
{
    public class BlobStoringDatabaseSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(BlobStoringDatabaseSettings.MySetting1));
        }
    }
}
