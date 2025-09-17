using MigrationsEntityFramework_AspNetCore.Schema;

namespace MigrationsEntityFramework_AspNetCore.Repositories.Interfaces;

public interface IEntityFrameworkRecordRepository
{
    Task<DBModels.EntityFrameworkRecord> Create(EntityFrameworkRecord record);

    Task<DBModels.EntityFrameworkRecord> Update(EntityFrameworkRecord record);

    Task Delete(EntityFrameworkRecord record);

    Task<DBModels.EntityFrameworkRecord>? GetBySolidId(int solidId);
    Task<DBModels.EntityFrameworkRecord>? GetById(int id);
}
