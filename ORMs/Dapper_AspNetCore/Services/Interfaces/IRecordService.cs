using Dapper_AspNetCore.Schema;

namespace Dapper_AspNetCore.Services.Interfaces;

public interface IRecordService
{
    Task<IEnumerable<Record>> GetAllAsync();
    Task<Record?> GetByIdSolidIdAsync(int solidId);
    Task<int> CreateAsync(Record record);
}
