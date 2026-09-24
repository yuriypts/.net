using AspNetCore.Identity_Authentication.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Identity_Authentication.DbContext;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(entity =>
        {
            entity.Property(e => e.Age).HasColumnName("Age").HasMaxLength(100);
        });

        builder.HasDefaultSchema("default");
    }
}
