
using Microsoft.EntityFrameworkCore;
using AspNetCore.Identity_Authentication.Database;
using AspNetCore.Identity_Authentication.DbContext;
using AspNetCore.Identity_Authentication.Extensions;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity_Authentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

            builder.Services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddApiEndpoints();

            //// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("EntityFrameworkConnectionString")));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.ApplyMigrations();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.MapIdentityApi<User>();

            app.Run();
        }
    }
}
