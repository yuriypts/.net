using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBAC_ABAC_ReBAC.RBAC;

namespace RBAC_ABAC_ReBAC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RBACController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = Permissions.DocumentsRead)]
    public IActionResult GetDocuments()
    {
        return Ok("Documents retrieved");
    }

    [HttpPut("{id:int}")]
    [Authorize(Policy = Permissions.DocumentsUpdate)]
    public IActionResult UpdateDocument(int id)
    {
        return Ok($"Document {id} updated");
    }

    [HttpDelete("{id:int}")]
    [Authorize(Policy = Permissions.DocumentsDelete)]
    public IActionResult DeleteDocument(int id)
    {
        return Ok($"Document {id} deleted");
    }

    [HttpPost("{id:int}/approve")]
    [Authorize(Policy = Permissions.DocumentsApprove)]
    public IActionResult ApproveDocument(int id)
    {
        return Ok($"Document {id} approved");
    }
}
