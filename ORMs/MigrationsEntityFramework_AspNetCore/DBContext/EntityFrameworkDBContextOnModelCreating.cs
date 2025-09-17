using Microsoft.EntityFrameworkCore;
using MigrationsEntityFramework_AspNetCore.DBModels;

namespace MigrationsEntityFramework_AspNetCore.DBContext;

public partial class EntityFrameworkDBContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //// Configure the EntityFrameworkRecord entity
        //modelBuilder.Entity<EntityFrameworkRecord>()
        //    .HasKey(i => i.Id)
        //    .HasName("PK_EntityFrameworkRecord");
        //modelBuilder.Entity<EntityFrameworkRecord>()
        //    .Property(i => i.Id)
        //    .HasColumnName("Id")
        //    .ValueGeneratedOnAdd();
        //modelBuilder.Entity<EntityFrameworkRecord>()
        //    .Property(i => i.SolidId)
        //    .IsRequired()
        //    .HasColumnName("SolidId");
        //modelBuilder.Entity<EntityFrameworkRecord>()
        //    .HasIndex(i => i.SolidId)
        //    .IsUnique();
        //modelBuilder.Entity<EntityFrameworkRecord>()
        //    .Property(i => i.Name)
        //    .HasColumnName("Name")
        //    .IsRequired(false);
        
        // Alternatively, using a more concise syntax
        modelBuilder.Entity<EntityFrameworkRecord>(entity =>
        {
            entity.ToTable("EntityFrameworkRecord");
            entity.HasKey(e => e.Id)
                  .HasName("PK_EntityFrameworkRecord");
            entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .ValueGeneratedOnAdd();
            entity.Property(e => e.SolidId)
                  .IsRequired()
                  .HasColumnName("SolidId");
            entity.HasIndex(e => e.SolidId)
                  .IsUnique();
            entity.Property(e => e.Name)
                  .HasColumnName("Name")
                  .IsRequired(false);
        });


        base.OnModelCreating(modelBuilder);
    }
}
