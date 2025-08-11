
using Microsoft.AspNetCore.Mvc;
using TestNHibernate.Repositories;
using TestNHibernate.Repositories.Interfaces;
using TestNHibernate.Services;
using TestNHibernate.Services.Interfaces;
using TestNHibernate.SessionFactory;
using TestNHibernate.SessionFactory.Interfaces;
using TestNHibernate.Shema;

namespace TestNHibernate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<INHibernateSessionFactory, NHibernateSessionFactory>();
            builder.Services.AddTransient<IRecordRepository, RecordRepository>();
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

            app.MapPost("/create", (IRecordService recordService, [FromBody] Record record) =>
            {
                var response = recordService.CreateRecord(record);
                return response;
            })
            .WithName("CreateRecord")
            .WithOpenApi();

            app.MapGet("/{solidId}", (int solidId, IRecordService recordService) =>
            {
                var response = recordService.GetRecord(solidId);
                return response;
            })
            .WithName("GetRecord")
            .WithOpenApi();

            app.Run();
        }
    }
}
