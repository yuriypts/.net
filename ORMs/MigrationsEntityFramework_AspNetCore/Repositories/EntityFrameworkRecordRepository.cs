using Microsoft.Data.SqlClient;
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
        return record;
    }

    public async Task<DBModels.EntityFrameworkRecord>? GetById(int id)
    {
        DBModels.EntityFrameworkRecord? record = await _dBContext.EntityFrameworkRecords.FirstOrDefaultAsync(x => x.Id == id);
        return record;
    }

    public async Task<List<DBModels.EntityFrameworkRecord>> GetAllRecords()
    {
        List<DBModels.EntityFrameworkRecord> records = await _dBContext.EntityFrameworkRecords.ToListAsync();
        return records;
    }

    public async Task<List<DBModels.EntityFrameworkRecord>> GetAllRecordsSql()
    {
        //List<DBModels.EntityFrameworkRecord> records = await _dBContext.EntityFrameworkRecords.FromSql($"SELECT * FROM EntityFrameworkRecord").ToListAsync();

        // slower performance, because the filtering is done in memory, not in the database
        //List<DBModels.EntityFrameworkRecord> records = await _dBContext.EntityFrameworkRecords.FromSql($"SELECT * FROM EntityFrameworkRecord")
        //    .Where(x => x.SolidId > 2)
        //    .ToListAsync();

        string sql = $"SELECT * FROM EntityFrameworkRecord";
        List<DBModels.EntityFrameworkRecord> records = await _dBContext.EntityFrameworkRecords.FromSqlRaw(sql).ToListAsync();
        return records;
    }

    public async Task<DBModels.EntityFrameworkRecord>? GetBySolidIdSql(int solidId)
    {
        // injection vulnerability (sql attact), do not use in production code
        //string sql = $"SELECT * FROM EntityFrameworkRecord WHERE SolidId = {solidId}";
        //DBModels.EntityFrameworkRecord? record = await _dBContext.EntityFrameworkRecords
        //    .FromSqlRaw(sql)
        //    .FirstOrDefaultAsync();
        //return record;

        SqlParameter sqlParameter = new("SolidId", solidId);
        string sql = "SELECT * FROM EntityFrameworkRecord WHERE SolidId = @SolidId";

        DBModels.EntityFrameworkRecord? record = await _dBContext.EntityFrameworkRecords
            .FromSqlRaw(sql, sqlParameter)
            .FirstOrDefaultAsync();
        
        return record;
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
