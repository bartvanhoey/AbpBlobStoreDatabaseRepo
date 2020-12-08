using Volo.Abp.Settings;

namespace AbpBlobStoreDatabase.Settings
{
    public class AbpBlobStoreDatabaseSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpBlobStoreDatabaseSettings.MySetting1));
        }
    }
}
