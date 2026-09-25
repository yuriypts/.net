using AspNetCore.JWT_Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.JWT_Authentication.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class InfoController : ControllerBase
{
    private readonly IUserService _userService;

    public InfoController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetInfo()
    {
        var info = new
        {
            ApplicationName = "AspNetCore.JWT_Authentication",
            Version = "1.0.0",
            Description = "A sample ASP.NET Core application demonstrating JWT authentication."
        };
        return Ok(info);
    }

    [HttpGet("user/{email}")]
    public async Task<IActionResult> GetUserInfo(string email)
    {
        var user = await _userService.GetUserByEmail(email);
        
        if (user == null)
        {
            return NotFound(new { Message = "User not found." });
        }

        return Ok(user);
    }
}
