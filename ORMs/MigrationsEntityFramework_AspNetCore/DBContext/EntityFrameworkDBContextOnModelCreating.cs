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
            entity.Property(e => e.DriveCloudId)
                  .HasColumnName("DriveCloudId")
                  .IsRequired(false);
            //entity.HasOne(e => e.DriveCloud)
            //      .WithMany()
            //      .HasForeignKey(e => e.DriveCloudId)
            //      .HasConstraintName("FK_Person_DriveCloud");
        });

        // one-to-many relationship between Person and DriveCloud
        modelBuilder.Entity<Person>()
            .HasOne(p => p.DriveCloud)
            .WithMany(p => p.Persons)
            .OnDelete(DeleteBehavior.Cascade);

        // many-to-many relationship between Person and PersonChat through ChatRelation
        modelBuilder.Entity<ChatRelation>()
            .HasOne(p => p.Person)
            .WithMany(p => p.ChatRelations)
            .HasForeignKey(p => p.PersonId);

        modelBuilder.Entity<ChatRelation>()
            .HasOne(p => p.PersonChat)
            .WithMany(p => p.ChatRelations)
            .HasForeignKey(p => p.PersonChatId);


        base.OnModelCreating(modelBuilder);
    }
}
