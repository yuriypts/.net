using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MigrationsEntityFramework_AspNetCore.DBContext;
using MigrationsEntityFramework_AspNetCore.DBContext.Interfaces;
using MigrationsEntityFramework_AspNetCore.Repositories;
using MigrationsEntityFramework_AspNetCore.Repositories.Interfaces;
using MigrationsEntityFramework_AspNetCore.Schema;
using MigrationsEntityFramework_AspNetCore.Services;
using MigrationsEntityFramework_AspNetCore.Services.Interfaces;

namespace TestMigrationsEntityFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // posible multiple DBContexts
            builder.Services.AddDbContext<EntityFrameworkDBContext>((serviceProvider, options) =>
            {
                // optional migrations assembly if needed
                //options.UseSqlServer(builder.Configuration.GetConnectionString("EntityFrameworkDBContext"), actions => actions.MigrationsAssembly("ProjectName"));
                options.UseSqlServer(builder.Configuration.GetConnectionString("EntityFrameworkConnectionString"));
            });

            builder.Services.AddScoped<IEntityFrameworkDBContext>(p => p.GetRequiredService<EntityFrameworkDBContext>());

            //builder.Services.AddScoped<INHibernateSessionFactory, NHibernateSessionFactory>();
            builder.Services.AddTransient<IEntityFrameworkRecordRepository, EntityFrameworkRecordRepository>();
            builder.Services.AddScoped<IEntityFrameworkRecordService, EntityFrameworkRecordService>();

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

            app.MapPost("/create", (IEntityFrameworkRecordService recordService, [FromBody] EntityFrameworkRecord record) =>
            {
                var response = recordService.CreateRecord(record);
                return response;
            })
            .WithName("CreateRecord")
            .WithOpenApi();

            app.MapGet("/{solidId}", (int solidId, IEntityFrameworkRecordService recordService) =>
            {
                var response = recordService.GetRecord(solidId);
                return response;
            })
            .WithName("GetRecord")
            .WithOpenApi();

            app.MapGet("/sql/{solidId}", (int solidId, IEntityFrameworkRecordService recordService) =>
            {
                var response = recordService.GetRecordSql(solidId);
                return response;
            })
           .WithName("GetRecordSql")
           .WithOpenApi();

            app.MapGet("/list", (IEntityFrameworkRecordService recordService) =>
            {
                var response = recordService.GetRecords();
                return response;
            })
            .WithName("GetRecords")
            .WithOpenApi();

            app.MapGet("/list-sql", (IEntityFrameworkRecordService recordService) =>
            {
                var response = recordService.GetRecordsSql();
                return response;
            })
            .WithName("GetRecordsSql")
            .WithOpenApi();

            app.Run();
        }
    }
}
