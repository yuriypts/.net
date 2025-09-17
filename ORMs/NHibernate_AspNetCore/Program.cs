
using Microsoft.AspNetCore.Mvc;
using NHibernate_AspNetCore.Repositories;
using NHibernate_AspNetCore.Repositories.Interfaces;
using NHibernate_AspNetCore.Services;
using NHibernate_AspNetCore.Services.Interfaces;
using NHibernate_AspNetCore.SessionFactory;
using NHibernate_AspNetCore.SessionFactory.Interfaces;
using NHibernate_AspNetCore.Shema;

namespace TestNHibernate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<INHibernateSessionFactory, NHibernateSessionFactory>();
            builder.Services.AddTransient<INHibernateRecordRepository, NHibernateRecordRepository>();
            builder.Services.AddScoped<INHibernateRecordService, NHibernateRecordService>();

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

            app.MapPost("/create", (INHibernateRecordService recordService, [FromBody] NHibernateRecord record) =>
            {
                var response = recordService.CreateRecord(record);
                return response;
            })
            .WithName("CreateRecord")
            .WithOpenApi();

            app.MapGet("/{solidId}", (int solidId, INHibernateRecordService recordService) =>
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
