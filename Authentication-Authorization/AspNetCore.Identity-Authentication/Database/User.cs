using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity_Authentication.Database;

public class User : IdentityUser
{
    public int? Age { get; set; }
}
