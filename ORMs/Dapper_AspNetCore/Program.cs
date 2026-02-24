
using Dapper_AspNetCore.Repositories;
using Dapper_AspNetCore.Repositories.Interfaces;
using Dapper_AspNetCore.Schema;
using Dapper_AspNetCore.Services;
using Dapper_AspNetCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper_AspNetCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register IDbConnection for DI
        var test = builder.Configuration.GetConnectionString("DatabaseConnectionString");
        builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DatabaseConnectionString")));

        builder.Services.AddScoped<IRecordRepository, RecordRepository>();
        builder.Services.AddScoped<IRecordService, RecordService>();

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapPost("/create", async (IRecordService recordService, [FromBody] Record record) =>
        {
            var response = await recordService.CreateAsync(record);
            return response;
        })
        .WithName("CreateRecord")
        .WithOpenApi();

        app.MapGet("/{solidId}", async (int solidId, IRecordService recordService) =>
        {
            var response = await recordService.GetByIdSolidIdAsync(solidId);
            return response;
        })
        .WithName("GetRecordBySolidId")
        .WithOpenApi();

        app.MapGet("/list", async (IRecordService recordService) =>
        {
            var response = await recordService.GetAllAsync();
            return response;
        })
       .WithName("GetRecords")
       .WithOpenApi();

        app.Run();
    }
}
