
using EF_Eager_Lazy_Explicit_Loading.DatabaseContext;
using EF_Eager_Lazy_Explicit_Loading.Repositories;
using EF_Eager_Lazy_Explicit_Loading.Repositories.Interfaces;
using EF_Eager_Lazy_Explicit_Loading.Services;
using EF_Eager_Lazy_Explicit_Loading.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF_Eager_Lazy_Explicit_Loading;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<ISoftwareEngineerService, SoftwareEngineerService>();
        builder.Services.AddTransient<ISoftwareEngineerRepository, SoftwareEngineerRepository>();

        builder.Services.AddScoped<IDeviceService, DeviceService>();
        builder.Services.AddTransient<IDeviceRepository, DeviceRepository>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
