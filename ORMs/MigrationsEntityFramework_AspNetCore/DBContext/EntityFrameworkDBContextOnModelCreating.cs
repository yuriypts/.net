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

        modelBuilder.Entity<DriveCloud>(entity =>
        {
            entity.ToTable("DriveCloud");
            entity.HasKey(e => e.Id)
                  .HasName("PK_DriveCloud");
            entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .ValueGeneratedOnAdd();
            entity.Property(e => e.Parth)
                  .HasColumnName("Path")
                  .IsRequired();
            entity.Property(e => e.Document)
                  .HasColumnName("Document")
                  .IsRequired();
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");
            entity.HasKey(e => e.Id)
                  .HasName("PK_Person");
            entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                  .HasColumnName("Name")
                  .IsRequired();
            //entity.HasOne(e => e.DriveCloud)
            //      .WithMany()
            //      .HasForeignKey(e => e.DriveCloudId)
            //      .HasConstraintName("FK_Person_DriveCloud");
        });

        // Case 1 - Primary Key for the join table ChatPersonRelation
        modelBuilder.Entity<ChatPersonRelation>()
            .HasKey(e => e.Id);

        // Case 2 - Composite Primary Key for the join table ChatPersonRelation
        modelBuilder.Entity<ChatPersonRelation>()
            .HasKey(x => new { x.ChatId, x.PersonId });

        //one - to - many relationship between Person and DriveCloud
        modelBuilder.Entity<Person>()
            .HasOne(p => p.DriveCloud)
            .WithMany(p => p.Persons);

        //many - to - many relationship between Person and PersonChat through ChatRelation
        modelBuilder.Entity<ChatPersonRelation>()
            .HasOne(p => p.Person)
            .WithMany(p => p.ChatPersonRelations)
            .HasForeignKey(p => p.PersonId);

        modelBuilder.Entity<ChatPersonRelation>()
            .HasOne(p => p.Chat)
            .WithMany(p => p.ChatPersonRelations)
            .HasForeignKey(p => p.ChatId);


        base.OnModelCreating(modelBuilder);
    }
}
