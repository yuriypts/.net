using MigrationsEntityFramework_AspNetCore.DBContext.Interfaces;
using MigrationsEntityFramework_AspNetCore.Repositories.Interfaces;
using MigrationsEntityFramework_AspNetCore.Schema;
using MigrationsEntityFramework_AspNetCore.Services.Interfaces;

namespace MigrationsEntityFramework_AspNetCore.Services;

public class EntityFrameworkRecordService : IEntityFrameworkRecordService
{
    private readonly IEntityFrameworkRecordRepository _recordRepository;

    public EntityFrameworkRecordService(IEntityFrameworkRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public async Task<EntityFrameworkRecord> CreateRecord(EntityFrameworkRecord record)
    {
        //if (record is null)
        //{
        //    throw new ArgumentNullException(nameof(record));
        //}

        ArgumentNullException.ThrowIfNull(record);

        DBModels.EntityFrameworkRecord? dbRecord = await _recordRepository.GetBySolidId(record.SolidId);
        if (dbRecord is not null)
        {
            throw new ArgumentException($"EntityFrameworkRecord with SolidId {record.SolidId} already exists.");
        }

        DBModels.EntityFrameworkRecord createdRecord = await _recordRepository.Create(record);

        return new EntityFrameworkRecord
        {
            Id = createdRecord.Id,
            SolidId = createdRecord.SolidId,
            Name = createdRecord.Name
        };
    }

    public async Task<EntityFrameworkRecord> GetRecord(int id)
    {
        DBModels.EntityFrameworkRecord? dbRecord = await _recordRepository.GetBySolidId(id);
        ArgumentNullException.ThrowIfNull(dbRecord);

        return new EntityFrameworkRecord
        {
            Id = dbRecord.Id,
            SolidId = dbRecord.SolidId,
            Name = dbRecord.Name
        };
    }

    public async Task<List<EntityFrameworkRecord>> GetRecords()
    {
        List<DBModels.EntityFrameworkRecord> dbRecords = await _recordRepository.GetAllRecords();
        
        return dbRecords.Select(dbRecord => new EntityFrameworkRecord
        {
            Id = dbRecord.Id,
            SolidId = dbRecord.SolidId,
            Name = dbRecord.Name
        }).ToList();
    }

    public async Task<EntityFrameworkRecord> UpdateRecord(EntityFrameworkRecord record)
    {
        ArgumentNullException.ThrowIfNull(record);
        DBModels.EntityFrameworkRecord updatedRecord = await _recordRepository.Update(record);

        return new EntityFrameworkRecord
        {
            Id = updatedRecord.Id,
            SolidId = updatedRecord.SolidId,
            Name = updatedRecord.Name
        };
    }

    public async Task DeleteRecord(int id)
    {
        EntityFrameworkRecord entityFrameworkRecord = await GetRecord(id);
        await _recordRepository.Delete(entityFrameworkRecord);
    }
}
