using Microsoft.AspNetCore.Authorization;
using RBAC_ABAC_ReBAC.Models;
using RBAC_ABAC_ReBAC.ReBAC;
using RBAC_ABAC_ReBAC.ReBAC.RelationStore;

public sealed class DocumentReadRelationshipHandler: AuthorizationHandler<DocumentReadRelationshipRequirement, Document>
{
    private readonly IRelationshipStore _relationshipStore;

    public DocumentReadRelationshipHandler(IRelationshipStore relationshipStore)
    {
        _relationshipStore = relationshipStore;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, DocumentReadRelationshipRequirement requirement, Document document)
    {
        var userDepartment = context.User.FindFirst("department")?.Value;

        if (string.IsNullOrWhiteSpace(userDepartment))
        {
            return;
        }

        var department = $"department:{userDepartment}";

        var resource = $"document:{document.Id}";

        var isOwner =
            await _relationshipStore.HasRelationshipAsync(
                department,
                Relations.Owner,
                resource);

        var isViewer =
            await _relationshipStore.HasRelationshipAsync(
                department,
                Relations.Viewer,
                resource);

        var isEditor =
            await _relationshipStore.HasRelationshipAsync(
                department,
                Relations.Editor,
                resource);

        if (!(isOwner && isViewer && isEditor))
        {
            return;
        }

        context.Succeed(requirement);
        return;
    }
}