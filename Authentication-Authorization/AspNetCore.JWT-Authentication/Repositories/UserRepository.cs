using AspNetCore.JWT_Authentication.Database;
using AspNetCore.JWT_Authentication.DatabaseContext;
using AspNetCore.JWT_Authentication.Repositories.Interfaces;

namespace AspNetCore.JWT_Authentication.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dBContext;

    public UserRepository(ApplicationDbContext dBContext)
    {
        _dBContext = dBContext;
    }

    public async Task<User?> Create(User user)
    {
        _dBContext.Users.Add(user);
        await _dBContext.SaveChangesAsync();

        return await GetUserByEmail(user.Email);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        User? user = _dBContext.Users.FirstOrDefault(x => x.Email == email);
        return user;
    }
}
