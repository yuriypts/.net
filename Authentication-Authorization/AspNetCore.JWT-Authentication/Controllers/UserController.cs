using AspNetCore.JWT_Authentication.Models;
using AspNetCore.JWT_Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.JWT_Authentication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] UserRegisterModel userRegisterModel)
    {
        var user = await _userService.RegisterAsync(userRegisterModel);
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginModel userLoginModel)
    {
        var token = await _userService.LoginAsync(userLoginModel);

        //_httpContext.Response.Cookies.Append("jwt-test", token);

        return Ok(new { Token = token });
    }
}
