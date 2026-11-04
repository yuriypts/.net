namespace RBAC_ABAC_ReBAC.Models;

public record UserLoginModel(string Email, string Role, string Department, string Classification, bool IsActive);
