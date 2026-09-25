using Microsoft.EntityFrameworkCore;
using AspNetCore.Identity_Authentication.Database;
using AspNetCore.Identity_Authentication.DbContext;
using AspNetCore.Identity_Authentication.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AspNetCore.Identity_Authentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication()
                .AddCookie(IdentityConstants.ApplicationScheme)
                .AddBearerToken(IdentityConstants.BearerScheme);
            //builder.Services.AddAuthentication()
            //    .AddBearerToken(IdentityConstants.BearerScheme);
            //builder.Services.AddAuthentication()
            //    .AddOAuth("OAuth", options => { });

            builder.Services.AddControllers();

            builder.Services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddApiEndpoints(); // required services for Identity API endpoints

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("EntityFrameworkConnectionString")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
           
            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapGet("/user", async (ClaimsPrincipal claimsPrincipal, ApplicationDbContext applicationDbContext) =>
            {
                string userId = claimsPrincipal.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

                var user = await applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

                return user;
            }).RequireAuthorization();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapIdentityApi<User>();

            app.MapControllers();

            app.Run();
        }
    }
}
