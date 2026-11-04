namespace RBAC_ABAC_ReBAC.RBAC;

public static class RolePermissions
{
    public static readonly Dictionary<string, string[]> Permissions =
        new()
        {
            [AppRoles.Admin] =
            [
                RBAC.Permissions.DocumentsRead,
                RBAC.Permissions.DocumentsUpdate,
                RBAC.Permissions.DocumentsDelete,
                RBAC.Permissions.DocumentsApprove
            ],

            [AppRoles.Manager] =
            [
                RBAC.Permissions.DocumentsRead,
                RBAC.Permissions.DocumentsUpdate,
                RBAC.Permissions.DocumentsApprove
            ],

            [AppRoles.Reader] =
            [
                RBAC.Permissions.DocumentsRead
            ]
        };
}
