using EF_Eager_Lazy_Explicit_Loading.Schema;
using EF_Eager_Lazy_Explicit_Loading.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EF_Eager_Lazy_Explicit_Loading.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SoftwareEngineerController : ControllerBase
{
    private readonly ISoftwareEngineerService _softwareEngineerService;

    public SoftwareEngineerController(ISoftwareEngineerService softwareEngineerService)
    {
        _softwareEngineerService = softwareEngineerService;
    }

    [HttpGet("{id}")]
    public async Task<SoftwareEngineer> Get(int id)
    {
        SoftwareEngineer sf = await _softwareEngineerService.Get(id);
        return sf;
    }

    [HttpGet()]
    public async Task<List<SoftwareEngineer>> GetList()
    {
        List<SoftwareEngineer> sfs = await _softwareEngineerService.GetList();
        return sfs;
    }
    
    [HttpGet("list-with-devices")]
    public async Task<List<SoftwareEngineer>> GetListWithDevices()
    {
        List<SoftwareEngineer> sfs = await _softwareEngineerService.GetListWithDevices();
        return sfs;
    }
    
    [HttpGet("list-eager-with-devices")]
    public async Task<List<SoftwareEngineer>> GetListEagerWithDevices()
    {
        List<SoftwareEngineer> sfs = await _softwareEngineerService.GetListEagerWithDevices();
        return sfs;
    }
    
    [HttpGet("list-explicit-with-devices")]
    public async Task<List<SoftwareEngineer>> GetListExplicitWithDevices()
    {
        List<SoftwareEngineer> sfs = await _softwareEngineerService.GetListExplicitWithDevices();
        return sfs;
    }
}
