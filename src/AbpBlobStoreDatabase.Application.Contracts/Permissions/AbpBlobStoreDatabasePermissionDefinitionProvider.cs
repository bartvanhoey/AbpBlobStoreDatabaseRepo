using AbpBlobStoreDatabase.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpBlobStoreDatabase.Permissions
{
    public class AbpBlobStoreDatabasePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpBlobStoreDatabasePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpBlobStoreDatabasePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpBlobStoreDatabaseResource>(name);
        }
    }
}
