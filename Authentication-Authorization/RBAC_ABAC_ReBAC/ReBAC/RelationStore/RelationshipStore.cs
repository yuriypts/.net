namespace RBAC_ABAC_ReBAC.ReBAC.RelationStore;

public sealed class RelationshipStore: IRelationshipStore
{
    private readonly HashSet<Relationship> _relationships =
    [
        new(
            "department:Development",
            Relations.Owner,
            "document:1"),

        new(
            "department:Marketing",
            Relations.Viewer,
            "document:2"),

        new(
            "department:HR",
            Relations.Editor,
            "document:3")
    ];

    public Task<bool> HasRelationshipAsync(string department, string relation, string resource)
    {
        var relationship = new Relationship(department, relation, resource);
        var exists = _relationships.Contains(relationship);

        return Task.FromResult(exists);
    }
}