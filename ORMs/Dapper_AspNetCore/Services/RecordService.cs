using Dapper_AspNetCore.Repositories.Interfaces;
using Dapper_AspNetCore.Schema;
using Dapper_AspNetCore.Services.Interfaces;

namespace Dapper_AspNetCore.Services;

public class RecordService : IRecordService
{
    private readonly IRecordRepository _recordRepository;

    public RecordService(IRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public async Task<int> CreateAsync(Record record)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(record);

            DBModels.Record? dbRecord = await _recordRepository.GetByIdSolidIdAsync(record.SolidId);
            if (dbRecord is not null)
            {
                throw new ArgumentException($"Record with SolidId {record.SolidId} already exists.");
            }

            DBModels.Record recordToCreate = new()
            {
                SolidId = record.SolidId,
                Name = record.Name
            };

            return await _recordRepository.CreateAsync(recordToCreate);
        }
        catch (Exception ex)
        {
            throw;
        }
        
    }

    public async Task<IEnumerable<Record>> GetAllAsync()
    {
        try
        {
            IEnumerable<DBModels.Record> dbRecords = await _recordRepository.GetAllAsync();

            return [.. dbRecords.Select(dbRecord => new Record
            {
                Id = dbRecord.Id,
                SolidId = dbRecord.SolidId,
                Name = dbRecord.Name
            })];
        }
        catch (Exception ex)
        {
            throw;
        }
        
    }

    public async Task<Record?> GetByIdSolidIdAsync(int solidId)
    {
        try
        {
            DBModels.Record? dbRecord = await _recordRepository.GetByIdSolidIdAsync(solidId);
            ArgumentNullException.ThrowIfNull(dbRecord);

            return new Record
            {
                Id = dbRecord.Id,
                SolidId = dbRecord.SolidId,
                Name = dbRecord.Name
            };
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
