using TestNHibernate.Repositories.Interfaces;
using TestNHibernate.Services.Interfaces;
using TestNHibernate.Shema;

namespace TestNHibernate.Services;

public class RecordService : IRecordService
{
    private readonly IRecordRepository _recordRepository;

    public RecordService(IRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public Record CreateRecord(Record record)
    {
        try
        {
            _recordRepository.Create(record);

            var dbRecord = _recordRepository.GetBySolidId(record.SolidId);

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

    public Record GetRecord(int solidId)
    {
        try
        {
            var dbRecord = _recordRepository.GetBySolidId(solidId);

            if (dbRecord is null)
            {
                throw new Exception($"Record with SolidId {solidId} not found.");
            }

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

    public Record UpdateRecord(Record payloadRecord)
    {
        try
        {
            Record record = GetRecord(payloadRecord.SolidId);

            if (record is null)
            {
                throw new Exception($"Record with SolidId {payloadRecord.SolidId} not found.");
            }

            DBModels.Record updatedRecord = _recordRepository.Update(payloadRecord);

            return new Record
            {
                Id = updatedRecord.Id,
                SolidId = updatedRecord.SolidId,
                Name = updatedRecord.Name
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DeleteRecord(int id)
    {
        try
        {
            Record record = GetRecord(id);
            
            if (record is null)
            {
                throw new Exception($"Record with SolidId {id} not found.");
            }

            _recordRepository.Delete(record);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
