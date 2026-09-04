using EF_Eager_Lazy_Explicit_Loading.Repositories.Interfaces;
using EF_Eager_Lazy_Explicit_Loading.Schema;
using EF_Eager_Lazy_Explicit_Loading.Services.Interfaces;

namespace EF_Eager_Lazy_Explicit_Loading.Services;

public class DeviceService : IDeviceService
{
    private readonly IDeviceRepository _deviceRepository;

    public DeviceService(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Device> GetById(int id)
    {
        DBModels.Device device = await _deviceRepository.GetById(id);
        return new Device
        {
            Id = device.Id,
            Type = device.Type,
            SoftwareEngineerId = device.SoftwareEngineerId,
        };
    }

    public async Task<List<Device>> GetList()
    {
        List<DBModels.Device> devices = await _deviceRepository.GetList();
        return devices.Select(d => new Device
        {
            Id = d.Id,
            Type = d.Type,
            SoftwareEngineerId = d.SoftwareEngineerId,
        }).ToList();
    }

    public async Task<List<Device>> GetListWithSoftwareEngineers()
    {
        List<DBModels.Device> devices = await _deviceRepository.GetListWithSoftwareEngineers();
        return devices.Select(d => new Device
        {
            Id = d.Id,
            Type = d.Type,
            SoftwareEngineerId = d.SoftwareEngineerId,
        }).ToList();
    }
}
