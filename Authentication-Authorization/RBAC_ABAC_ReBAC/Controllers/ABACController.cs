using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBAC_ABAC_ReBAC.Models;
using RBAC_ABAC_ReBAC.RBAC;

namespace RBAC_ABAC_ReBAC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ABACController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;

    public ABACController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> ApproveDocument(int id)
    {
        // Load the document from the database.
        var document = GetDocumentFromDatabase(id);

        if (document is null)
        {
            return NotFound();
        }

        // User is the current user principal, and document is the resource to check.
        var authorizationResult = await _authorizationService.AuthorizeAsync(User, document, Permissions.DocumentsApprove);

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
