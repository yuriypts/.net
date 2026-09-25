using AspNetCore.JWT_Authentication.Database;
using AspNetCore.JWT_Authentication.Models;

namespace AspNetCore.JWT_Authentication.Services.Interfaces;

public interface IUserService
{
    Task<User?> RegisterAsync(UserRegisterModel userRegister);
    Task<string> LoginAsync(UserLoginModel userLogin);
    Task<User?> GetUserByEmail(string email);
}
