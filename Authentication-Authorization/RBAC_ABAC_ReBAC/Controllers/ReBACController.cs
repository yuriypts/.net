using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBAC_ABAC_ReBAC.Models;
using RBAC_ABAC_ReBAC.RBAC;

namespace RBAC_ABAC_ReBAC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReBACController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;

    public ReBACController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDocument(int id)
    {
        var document = GetDocumentFromDatabase(id);

        if (document is null)
        {
            return NotFound();
        }

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, document, Permissions.DocumentsDelete);

        if (!authorizationResult.Succeeded)
        {
            return Forbid();
        }

        return Ok(document);
    }

    private Document? GetDocumentFromDatabase(int id)
    {
        if (id == 1)
        {
            return new Document()
            {
                Id = 1,
                Title = "Sample Document",
                Department = "Development",
                IsActive = true,
                Classification = "Internal",
                OwnerId = "user-123"
            };
        }

        return null;
    }
}
