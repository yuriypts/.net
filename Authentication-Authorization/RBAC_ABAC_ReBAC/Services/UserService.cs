using RBAC_ABAC_ReBAC.Models;
using RBAC_ABAC_ReBAC.Services.Interfaces;

namespace RBAC_ABAC_ReBAC.Services;

public class UserService : IUserService
{
    private readonly IJwtService _jwtService;

    public UserService(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public async Task<string> LoginAsync(UserLoginModel userLogin)
    {
        var token = _jwtService.GenerateToken(userLogin);

        return token;
    }
}
