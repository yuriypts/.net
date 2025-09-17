using Microsoft.EntityFrameworkCore;
using MigrationsEntityFramework_AspNetCore.DBContext.Interfaces;
using MigrationsEntityFramework_AspNetCore.DBModels;

namespace MigrationsEntityFramework_AspNetCore.DBContext;

public partial class EntityFrameworkDBContext : DbContext, IEntityFrameworkDBContext
{
    public DbSet<EntityFrameworkRecord> EntityFrameworkRecords { get; set; } = default!;

    public EntityFrameworkDBContext()
    {
    }

    public EntityFrameworkDBContext(DbContextOptions<EntityFrameworkDBContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // so runtime DI won't override
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=localhost;Initial Catalog=EntityFramework_AspNetCore;integrated security=SSPI;persist security info=False;Trusted_Connection=Yes;TrustServerCertificate=True;"
            );
        }
        base.OnConfiguring(optionsBuilder);
    }
}
