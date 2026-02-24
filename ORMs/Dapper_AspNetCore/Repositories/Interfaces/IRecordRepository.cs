using Dapper_AspNetCore.DBModels;

namespace Dapper_AspNetCore.Repositories.Interfaces;

public interface IRecordRepository
{
    Task<IEnumerable<Record>> GetAllAsync();
    Task<Record?> GetByIdSolidIdAsync(int solidId);
    Task<int> CreateAsync(Record record);
}
