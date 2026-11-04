using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RBAC_ABAC_ReBAC.Infrastructure;
using RBAC_ABAC_ReBAC.Models;
using RBAC_ABAC_ReBAC.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RBAC_ABAC_ReBAC.Services;

public class JwtService : IJwtService
{
    private readonly JWTOptions _jwtOptions;

    public JwtService(IOptions<JWTOptions> options)
    {
        _jwtOptions = options.Value;
    }

    public string GenerateToken(UserLoginModel userLogin)
    {
        Claim[] claims = new[]
        {
            new Claim(ClaimTypes.Email, userLogin.Email),
            new Claim(ClaimTypes.Role, userLogin.Role),
            new Claim("department", userLogin.Department),
            new Claim("classification", userLogin.Classification),
            new Claim("isActive", userLogin.IsActive.ToString().ToLower()),
        };

        JwtSecurityToken token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(_jwtOptions.ExpiredTime),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256Signature
            )
        );

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenValue;
    }
}
