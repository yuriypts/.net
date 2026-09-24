using AspNetCore.Identity_Authentication.DbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AspNetCore.Identity_Authentication.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("User ID not found in claims.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        return Ok(user);
    }
}
