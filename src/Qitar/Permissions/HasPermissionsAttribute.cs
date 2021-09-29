using System;

namespace Qitar.Permissions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HasPermissionsAttribute : Attribute
    {
        public string[] PermissionCodes { get; }

        public HasPermissionsAttribute(params string[] permissionCodes)
        {
            PermissionCodes = permissionCodes;
        }
    }
}
