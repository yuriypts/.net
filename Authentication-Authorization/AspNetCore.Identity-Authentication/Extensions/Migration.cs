using AspNetCore.Identity_Authentication.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Identity_Authentication.Extensions;

public static class Migration
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }
}
