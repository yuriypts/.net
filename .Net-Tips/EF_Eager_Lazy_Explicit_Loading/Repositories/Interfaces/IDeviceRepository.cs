using EF_Eager_Lazy_Explicit_Loading.DBModels;

namespace EF_Eager_Lazy_Explicit_Loading.Repositories.Interfaces;

public interface IDeviceRepository
{
    Task<Device> GetById(int id);
    Task<List<Device>> GetList();
    Task<List<Device>> GetListWithSoftwareEngineers();
}
