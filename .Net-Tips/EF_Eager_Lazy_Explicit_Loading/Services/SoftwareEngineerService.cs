using EF_Eager_Lazy_Explicit_Loading.Repositories.Interfaces;
using EF_Eager_Lazy_Explicit_Loading.Schema;
using EF_Eager_Lazy_Explicit_Loading.Services.Interfaces;

namespace EF_Eager_Lazy_Explicit_Loading.Services;

public class SoftwareEngineerService : ISoftwareEngineerService
{
    private readonly ISoftwareEngineerRepository _softwareEngineerRepository;

    public SoftwareEngineerService(ISoftwareEngineerRepository softwareEngineerRepository)
    {
        _softwareEngineerRepository = softwareEngineerRepository;
    }

    public async Task<SoftwareEngineer> Get(int id)
    {
        DBModels.SoftwareEngineer? dbSF = await _softwareEngineerRepository.GetById(id);
        ArgumentNullException.ThrowIfNull(dbSF);

        return new SoftwareEngineer
        {
            Id = dbSF.Id,
            Name = dbSF.Name,
        };
    }

    public async Task<List<SoftwareEngineer>> GetList()
    {
        List<DBModels.SoftwareEngineer> dbSFs = await _softwareEngineerRepository.GetList();
        return dbSFs.Select(dbSF => new SoftwareEngineer
        {
            Id = dbSF.Id,
            Name = dbSF.Name,
            Devices = dbSF.Devices.Select(device => new Device
            {
                Id = device.Id,
                Type = device.Type,
                SoftwareEngineerId = device.SoftwareEngineerId
            }).ToList()
        }).ToList();
    }

    public async Task<List<SoftwareEngineer>> GetListWithDevices()
    {
        List<DBModels.SoftwareEngineer> dbSFs = await _softwareEngineerRepository.GetListWithDevices();
        return dbSFs.Select(dbSF => new SoftwareEngineer
        {
            Id = dbSF.Id,
            Name = dbSF.Name,
            Devices = dbSF.Devices.Select(device => new Device
            {
                Id = device.Id,
                Type = device.Type,
                SoftwareEngineerId = device.SoftwareEngineerId
            }).ToList()
        }).ToList();
    }

    public async Task<List<SoftwareEngineer>> GetListEagerWithDevices()
    {
        List<DBModels.SoftwareEngineer> dbSFs = await _softwareEngineerRepository.GetListEagerWithDevices();
        return dbSFs.Select(dbSF => new SoftwareEngineer
        {
            Id = dbSF.Id,
            Name = dbSF.Name,
            Devices = dbSF.Devices.Select(device => new Device
            {
                Id = device.Id,
                Type = device.Type,
                SoftwareEngineerId = device.SoftwareEngineerId
            }).ToList()
        }).ToList();
    }

    public async Task<List<SoftwareEngineer>> GetListExplicitWithDevices()
    {
        List<DBModels.SoftwareEngineer> dbSFs = await _softwareEngineerRepository.GetListExplicitWithDevices();
        return dbSFs.Select(dbSF => new SoftwareEngineer
        {
            Id = dbSF.Id,
            Name = dbSF.Name,
            Devices = dbSF.Devices.Select(device => new Device
            {
                Id = device.Id,
                Type = device.Type,
                SoftwareEngineerId = device.SoftwareEngineerId
            }).ToList()
        }).ToList();
    }
}
