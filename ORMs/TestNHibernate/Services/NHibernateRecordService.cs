using NHibernate_AspNetCore.Repositories.Interfaces;
using NHibernate_AspNetCore.Services.Interfaces;
using NHibernate_AspNetCore.Shema;

namespace NHibernate_AspNetCore.Services;

public class NHibernateRecordService : INHibernateRecordService
{
    private readonly INHibernateRecordRepository _recordRepository;

    public NHibernateRecordService(INHibernateRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public NHibernateRecord CreateRecord(NHibernateRecord record)
    {
        try
        {
            _recordRepository.Create(record);

            var dbRecord = _recordRepository.GetBySolidId(record.SolidId);

            return new NHibernateRecord
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

    public NHibernateRecord GetRecord(int solidId)
    {
        try
        {
            var dbRecord = _recordRepository.GetBySolidId(solidId);

            if (dbRecord is null)
            {
                throw new Exception($"NHibernateRecord with SolidId {solidId} not found.");
            }

            return new NHibernateRecord
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

    public NHibernateRecord UpdateRecord(NHibernateRecord payloadRecord)
    {
        try
        {
            NHibernateRecord record = GetRecord(payloadRecord.SolidId);

            if (record is null)
            {
                throw new Exception($"NHibernateRecord with SolidId {payloadRecord.SolidId} not found.");
            }

            DBModels.NHibernateRecord updatedRecord = _recordRepository.Update(payloadRecord);

            return new NHibernateRecord
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
            NHibernateRecord record = GetRecord(id);
            
            if (record is null)
            {
                throw new Exception($"NHibernateRecord with SolidId {id} not found.");
            }

            _recordRepository.Delete(record);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
