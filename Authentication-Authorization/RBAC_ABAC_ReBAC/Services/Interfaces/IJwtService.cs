using RBAC_ABAC_ReBAC.Models;

namespace RBAC_ABAC_ReBAC.Services.Interfaces;

public interface IJwtService
{
    public string GenerateToken(UserLoginModel userLogin);
}

