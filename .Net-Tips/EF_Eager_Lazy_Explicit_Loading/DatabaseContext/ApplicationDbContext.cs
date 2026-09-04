using EF_Eager_Lazy_Explicit_Loading.DBModels;
using Microsoft.EntityFrameworkCore;

namespace EF_Eager_Lazy_Explicit_Loading.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<SoftwareEngineer> SoftwareEngineers { get; set; } = default!;
    public DbSet<Device> Devices { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<SoftwareEngineer>()
            .ToTable("SoftwareEngineer")
            .HasMany(se => se.Devices)
            .WithOne(d => d.SoftwareEngineer)
            .HasForeignKey(d => d.SoftwareEngineerId);

        modelBuilder.Entity<Device>()
            .ToTable("Devices")
            .HasOne(d => d.SoftwareEngineer)
            .WithMany(se => se.Devices)
            .HasForeignKey(d => d.SoftwareEngineerId);

        modelBuilder.Entity<SoftwareEngineer>().HasData(
                new SoftwareEngineer { Id = 1, Name = "Test1" },
                new SoftwareEngineer { Id = 2, Name = "Test2" }
            );

        modelBuilder.Entity<Device>().HasData(
                new Device { Id = 1, Type = "PC", SoftwareEngineerId = 1 },
                new Device { Id = 2, Type = "Laptop", SoftwareEngineerId = 1 },
                new Device { Id = 3, Type = "Mobile", SoftwareEngineerId = 2 }
            );
    }
}
