using AspNetCore.JWT_Authentication.Database;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.JWT_Authentication.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100);
            entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasColumnName("PasswordHash").HasMaxLength(256);
        });
    }
}
