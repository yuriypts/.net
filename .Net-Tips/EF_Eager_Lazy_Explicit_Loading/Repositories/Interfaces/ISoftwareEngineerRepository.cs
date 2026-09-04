using EF_Eager_Lazy_Explicit_Loading.DBModels;

namespace EF_Eager_Lazy_Explicit_Loading.Repositories.Interfaces;

public interface ISoftwareEngineerRepository
{
    Task<SoftwareEngineer> GetById(int id);
    Task<List<SoftwareEngineer>> GetList();
    Task<List<SoftwareEngineer>> GetListWithDevices();
    Task<List<SoftwareEngineer>> GetListEagerWithDevices();
    Task<List<SoftwareEngineer>> GetListExplicitWithDevices();
}
