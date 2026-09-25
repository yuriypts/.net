using AspNetCore.JWT_Authentication.Database;
using AspNetCore.JWT_Authentication.DatabaseContext;
using AspNetCore.JWT_Authentication.Infrastructure;
using AspNetCore.JWT_Authentication.Models;
using AspNetCore.JWT_Authentication.Repositories.Interfaces;
using AspNetCore.JWT_Authentication.Services.Interfaces;

namespace AspNetCore.JWT_Authentication.Services;

public class UserService : IUserService
{
    private readonly PasswordHash _passwordHash;
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public UserService(PasswordHash passwordHash, IUserRepository userRepository, IJwtService jwtService)
    {
        _passwordHash = passwordHash;
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<User?> RegisterAsync(UserRegisterModel userRegister)
    {
        var hashPassword = _passwordHash.HashPassword(userRegister.Password);
        return await _userRepository.Create(User.Create(userRegister.Name, userRegister.Email, hashPassword));
    }

    public async Task<string> LoginAsync(UserLoginModel userLogin)
    {
        var user = await _userRepository.GetUserByEmail(userLogin.Email);
        if (user == null)
        {
            throw new InvalidOperationException("Invalid email or password.");
        }

        if (!_passwordHash.VerifyPassword(userLogin.Password, user.PasswordHash))
        {
            throw new InvalidOperationException("Invalid email or password.");
        }

        var token = _jwtService.GenerateToken(userLogin.Email);

        return token;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _userRepository.GetUserByEmail(email);
    }
}
