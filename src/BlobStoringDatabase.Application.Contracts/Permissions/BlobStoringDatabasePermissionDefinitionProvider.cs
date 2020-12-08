using BlobStoringDatabase.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BlobStoringDatabase.Permissions
{
    public class BlobStoringDatabasePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BlobStoringDatabasePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(BlobStoringDatabasePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BlobStoringDatabaseResource>(name);
        }
    }
}
