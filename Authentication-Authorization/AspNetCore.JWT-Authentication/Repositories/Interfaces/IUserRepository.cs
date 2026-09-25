using AspNetCore.JWT_Authentication.Database;

namespace AspNetCore.JWT_Authentication.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> Create(User user);
    Task<User?> GetUserByEmail(string email);
}
