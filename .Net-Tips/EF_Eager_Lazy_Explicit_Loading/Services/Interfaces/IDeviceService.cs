using EF_Eager_Lazy_Explicit_Loading.Schema;

namespace EF_Eager_Lazy_Explicit_Loading.Services.Interfaces;

public interface IDeviceService
{
    Task<Device> GetById(int id);
    Task<List<Device>> GetList();
    Task<List<Device>> GetListWithSoftwareEngineers();
}
