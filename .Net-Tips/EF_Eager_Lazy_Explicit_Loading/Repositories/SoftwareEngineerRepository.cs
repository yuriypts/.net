using EF_Eager_Lazy_Explicit_Loading.DatabaseContext;
using EF_Eager_Lazy_Explicit_Loading.DBModels;
using EF_Eager_Lazy_Explicit_Loading.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF_Eager_Lazy_Explicit_Loading.Repositories;

public class SoftwareEngineerRepository : ISoftwareEngineerRepository
{
    private readonly ApplicationDbContext _dBContext;

    public SoftwareEngineerRepository(ApplicationDbContext dBContext)
    {
        _dBContext = dBContext;
    }


    public async Task<SoftwareEngineer> GetById(int id) 
    {
        SoftwareEngineer? softwareEngineer = await _dBContext.SoftwareEngineers.FirstOrDefaultAsync(se => se.Id == id);
        ArgumentNullException.ThrowIfNull(softwareEngineer);
        return softwareEngineer;
    }

    public async Task<List<SoftwareEngineer>> GetList()
    {
        // Lazy Loading (Deferred execution) by default is enabled in EF Core, so when we access the Devices property of a SoftwareEngineer,
        // EF Core will automatically load the related devices from the database. However,
        // this can lead to performance issues if we have many software engineers and we are accessing their devices in a loop, as it will result in multiple database queries (N+1 problem).
        IEnumerable<SoftwareEngineer> softwareEngineers = _dBContext.SoftwareEngineers;

        List<SoftwareEngineer> sfs = softwareEngineers.ToList();

        return sfs;
    }

    public async Task<List<SoftwareEngineer>> GetListWithDevices()
    {
        IEnumerable<SoftwareEngineer> softwareEngineers = _dBContext.SoftwareEngineers;

        List<SoftwareEngineer> sfs = softwareEngineers.ToList();

        // N+1 Problem: For each software engineer, we are making a separate database call to get their devices. This can lead to performance issues if there are many software engineers.
        foreach (var sf in sfs)
        {
            //sf.Devices = _dBContext.Devices.Where(x => x.SoftwareEngineerId == sf.Id).ToList();
            var dv = sf.Devices;
        }

        return sfs;
    }
    
    public async Task<List<SoftwareEngineer>> GetListEagerWithDevices()
    {
        //IEnumerable<SoftwareEngineer> softwareEngineers = _dBContext.SoftwareEngineers.Include(x => x.Devices);
        IEnumerable<SoftwareEngineer> softwareEngineers = _dBContext.SoftwareEngineers.Include(x => x.Devices).AsSplitQuery();

        List<SoftwareEngineer> sfs = softwareEngineers.ToList();

        return sfs;
    }

    public async Task<List<SoftwareEngineer>> GetListExplicitWithDevices()
    {
        IEnumerable<SoftwareEngineer> softwareEngineers = _dBContext.SoftwareEngineers;

        List<SoftwareEngineer> sfs = softwareEngineers.ToList();

        // Collection navigation property loading: For each software engineer, we are explicitly loading their devices using the Entry method.
        // This allows us to load related data on demand, rather than loading it automatically when we access the Devices property.

        // Reference vs Collection navigation property loading:
        // Reference navigation properties are used to navigate to a single related entity, while collection navigation properties are used to navigate to a collection of related entities.
        foreach (var sf in sfs)
        {
            if (sf.Name == "Test1")
            {
                _dBContext.Entry(sf).Collection(x => x.Devices).Load();
            }
        }

        return sfs;
    }
}
