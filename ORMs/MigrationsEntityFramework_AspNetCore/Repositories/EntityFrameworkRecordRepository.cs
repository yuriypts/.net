using Microsoft.EntityFrameworkCore;
using MigrationsEntityFramework_AspNetCore.DBContext.Interfaces;
using MigrationsEntityFramework_AspNetCore.Repositories.Interfaces;

namespace MigrationsEntityFramework_AspNetCore.Repositories;

public class EntityFrameworkRecordRepository : IEntityFrameworkRecordRepository
{
    private readonly IEntityFrameworkDBContext _dBContext;

    public EntityFrameworkRecordRepository(IEntityFrameworkDBContext dBContext)
    {
        _dBContext = dBContext;
    }

    public async Task<DBModels.EntityFrameworkRecord> Create(Schema.EntityFrameworkRecord record)
    {
        DBModels.EntityFrameworkRecord entityFrameworkRecord = new()
        {
            SolidId = record.SolidId,
            Name = record.Name
        };

        _dBContext.EntityFrameworkRecords.Add(entityFrameworkRecord);
        int id = await _dBContext.SaveChangesAsync();

        return await GetById(id);
    }

    public async Task Delete(Schema.EntityFrameworkRecord record)
    {
        DBModels.EntityFrameworkRecord? dbRecord = await GetById(record.Id);

        ArgumentNullException.ThrowIfNull(record);

        _dBContext.EntityFrameworkRecords.Remove(dbRecord);
        await _dBContext.SaveChangesAsync();
    }

    public async Task<DBModels.EntityFrameworkRecord>? GetBySolidId(int solidId)
    {
        DBModels.EntityFrameworkRecord? record = await _dBContext.EntityFrameworkRecords.FirstOrDefaultAsync(x => x.SolidId == solidId);

        ArgumentNullException.ThrowIfNull(record);

        return record;
    }

    public async Task<DBModels.EntityFrameworkRecord>? GetById(int id)
    {
        DBModels.EntityFrameworkRecord? record = await _dBContext.EntityFrameworkRecords.FirstOrDefaultAsync(x => x.Id == id);
        
        ArgumentNullException.ThrowIfNull(record);

        return record;
    }

    public async Task<List<DBModels.EntityFrameworkRecord>> GetAllRecords()
    {
        List<DBModels.EntityFrameworkRecord> records = await _dBContext.EntityFrameworkRecords.ToListAsync();
        return records;
    }

    public async Task<DBModels.EntityFrameworkRecord> Update(Schema.EntityFrameworkRecord record)
    {
        DBModels.EntityFrameworkRecord? dbRecord = await GetById(record.Id);

        ArgumentNullException.ThrowIfNull(record);

        dbRecord.SolidId = record.SolidId;
        dbRecord.Name = record.Name;

        int id = await _dBContext.SaveChangesAsync();

        return await GetById(id);
    }
}
