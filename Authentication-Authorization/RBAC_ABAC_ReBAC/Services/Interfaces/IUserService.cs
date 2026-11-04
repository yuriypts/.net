using RBAC_ABAC_ReBAC.Models;

namespace RBAC_ABAC_ReBAC.Services.Interfaces;

public interface IUserService
{
    Task<string> LoginAsync(UserLoginModel userLogin);
}

