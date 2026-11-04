using Microsoft.AspNetCore.Authorization;
using RBAC_ABAC_ReBAC.ABAC;
using RBAC_ABAC_ReBAC.Models;

public sealed class DocumentReadHandler : AuthorizationHandler<DocumentReadRequirement, Document>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DocumentReadRequirement requirement, Document document)
    {
        var userDepartment = context.User.FindFirst("department")?.Value;

        if (string.IsNullOrWhiteSpace(userDepartment) || (userDepartment != "Development"))
        {
            return Task.CompletedTask;
        }

        var isActive = context.User.FindFirst("isActive")?.Value;

        if (Boolean.TryParse(isActive, out bool isActiveValue) && !isActiveValue)
        {
            return Task.CompletedTask;
        }

        var classification = context.User.FindFirst("classification")?.Value;

        if (string.IsNullOrWhiteSpace(classification) || (classification != "Internal" && classification != "Public"))
        {
            return Task.CompletedTask;
        }

        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}