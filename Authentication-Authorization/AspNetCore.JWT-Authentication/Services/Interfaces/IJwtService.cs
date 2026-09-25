namespace AspNetCore.JWT_Authentication.Services.Interfaces;

public interface IJwtService
{
    public string GenerateToken(string email);
}
