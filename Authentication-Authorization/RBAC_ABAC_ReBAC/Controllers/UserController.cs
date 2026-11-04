using Microsoft.AspNetCore.Mvc;
using RBAC_ABAC_ReBAC.Models;
using RBAC_ABAC_ReBAC.Services.Interfaces;

namespace RBAC_ABAC_ReBAC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginModel userLoginModel)
    {
        var token = await _userService.LoginAsync(userLoginModel);
        return Ok(token);
    }
}
