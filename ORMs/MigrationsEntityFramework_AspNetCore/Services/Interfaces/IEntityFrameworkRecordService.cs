
using MigrationsEntityFramework_AspNetCore.Schema;

namespace MigrationsEntityFramework_AspNetCore.Services.Interfaces;

public interface IEntityFrameworkRecordService
{
    Task<EntityFrameworkRecord> CreateRecord(EntityFrameworkRecord record);
    Task<EntityFrameworkRecord> GetRecord(int id);
    Task<EntityFrameworkRecord> GetRecordSql(int id);
    Task<List<EntityFrameworkRecord>> GetRecords();
    Task<List<EntityFrameworkRecord>> GetRecordsSql();
    Task<EntityFrameworkRecord> UpdateRecord(EntityFrameworkRecord record);
    Task DeleteRecord(int id);
}
