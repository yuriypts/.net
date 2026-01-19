
using MigrationsEntityFramework_AspNetCore.Schema;

namespace MigrationsEntityFramework_AspNetCore.Services.Interfaces;

public interface IEntityFrameworkRecordService
{
    Task<EntityFrameworkRecord> CreateRecord(EntityFrameworkRecord record);
    Task<EntityFrameworkRecord> GetRecord(int id);
    Task<List<EntityFrameworkRecord>> GetRecords();
    Task<EntityFrameworkRecord> UpdateRecord(EntityFrameworkRecord record);
    Task DeleteRecord(int id);
}
