namespace RBAC_ABAC_ReBAC.Infrastructure;

public class JWTOptions
{
    public string SecretKey { get; set; } = string.Empty;
    public int ExpiredTime { get; set; }
}