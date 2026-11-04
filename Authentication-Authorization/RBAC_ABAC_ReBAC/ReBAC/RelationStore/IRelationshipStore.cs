namespace RBAC_ABAC_ReBAC.ReBAC.RelationStore;

public interface IRelationshipStore
{
    Task<bool> HasRelationshipAsync(string department, string relation, string resource);
}