using EF_Eager_Lazy_Explicit_Loading.Schema;

namespace EF_Eager_Lazy_Explicit_Loading.Services.Interfaces;

public interface ISoftwareEngineerService
{
    Task<SoftwareEngineer> Get(int id);
    Task<List<SoftwareEngineer>> GetList();
    Task<List<SoftwareEngineer>> GetListWithDevices();
    Task<List<SoftwareEngineer>> GetListEagerWithDevices();
    Task<List<SoftwareEngineer>> GetListExplicitWithDevices();
}
