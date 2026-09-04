using EF_Eager_Lazy_Explicit_Loading.Schema;
using EF_Eager_Lazy_Explicit_Loading.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_Eager_Lazy_Explicit_Loading.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeviceController : ControllerBase
{
    private readonly IDeviceService _deviceService;

    public DeviceController(IDeviceService deviceService)
    {
        _deviceService = deviceService;
    }

    [HttpGet("{id}")]
    public async Task<Device> GetById(int id)
    {
        Device device = await _deviceService.GetById(id);
        return device;
    }

    [HttpGet]
    public async Task<List<Device>> GetList()
    {
        List<Device> devices = await _deviceService.GetList();
        return devices;
    }


    [HttpGet("list-with-software-engineers")]
    public async Task<List<Device>> GetListWithSoftwareEngineers()
    {
        List<Device> devices = await _deviceService.GetListWithSoftwareEngineers();
        return devices;
    }
}
