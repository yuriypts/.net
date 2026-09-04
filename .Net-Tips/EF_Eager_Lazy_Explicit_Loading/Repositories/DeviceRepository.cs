using EF_Eager_Lazy_Explicit_Loading.DatabaseContext;
using EF_Eager_Lazy_Explicit_Loading.DBModels;
using EF_Eager_Lazy_Explicit_Loading.Repositories.Interfaces;

namespace EF_Eager_Lazy_Explicit_Loading.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly ApplicationDbContext _dBContext;

    public DeviceRepository(ApplicationDbContext dBContext)
    {
        _dBContext = dBContext;
    }

    public async Task<Device> GetById(int id)
    {
        Device? device = _dBContext.Devices.FirstOrDefault(x => x.Id == id);

        return device;
    }

    public async Task<List<Device>> GetList()
    {
        IEnumerable<Device> devices = _dBContext.Devices;

        List<Device> dvs = devices.ToList();

        return dvs;
    }

    public async Task<List<Device>> GetListWithSoftwareEngineers()
    {
        IEnumerable<Device> devices = _dBContext.Devices;

        List<Device> dvs = devices.ToList();

        foreach (var dv in dvs)
        {
            dv.SoftwareEngineer = _dBContext.SoftwareEngineers.FirstOrDefault(x => x.Id == dv.SoftwareEngineerId);
        }

        return dvs;
    }
}
