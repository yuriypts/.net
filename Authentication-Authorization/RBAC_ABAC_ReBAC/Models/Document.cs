namespace RBAC_ABAC_ReBAC.Models;

public sealed class Document
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Department { get; set; } = string.Empty;

    public string OwnerId { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public string Classification { get; set; } = "Internal";
}