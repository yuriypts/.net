using Dapper;
using Dapper_AspNetCore.DBModels;
using Dapper_AspNetCore.Repositories.Interfaces;
using System.Data;

namespace Dapper_AspNetCore.Repositories;

public class RecordRepository : IRecordRepository
{
    private readonly IDbConnection _db;

    public RecordRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Record>> GetAllAsync()
    {
        var sql = "SELECT Id, Name, SolidId FROM Record";
        return await _db.QueryAsync<Record>(sql);
    }

    public async Task<Record?> GetByIdSolidIdAsync(int solidId)
    {
        //strongly typed
        //output parameters
        //stored procedures
        //nullable handling
        //multiple params
        string sql = "SELECT * FROM Record WHERE SolidId = @SolidId";
        DynamicParameters parameters = new();
        parameters.Add("@SolidId", solidId, DbType.Int32);
        return await _db.QueryFirstOrDefaultAsync<Record>(sql, parameters);

        //var sql = "SELECT Id, Name, SolidId FROM Record WHERE Id = @Id";
        //return await _db.QueryFirstOrDefaultAsync<Record>(sql, new { Id = solidId });
    }

    public async Task<int> CreateAsync(Record record)
    {
        var sql = @"INSERT INTO Record (Name, SolidId) VALUES (@Name, @SolidId); SELECT CAST(SCOPE_IDENTITY() as int);";
        DynamicParameters parameters = new();
        parameters.Add("@Name", record.Name, DbType.String);
        parameters.Add("@SolidId", record.SolidId, DbType.Int32);
        return await _db.ExecuteScalarAsync<int>(sql, parameters);

        //var sql = @"INSERT INTO Record (Name, SolidId) VALUES (@Name, @SolidId); SELECT CAST(SCOPE_IDENTITY() as int)";
        //return await _db.ExecuteScalarAsync<int>(sql, record);
    }
}
