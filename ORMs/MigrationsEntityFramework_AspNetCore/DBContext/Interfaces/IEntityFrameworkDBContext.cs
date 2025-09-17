using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MigrationsEntityFramework_AspNetCore.DBModels;

namespace MigrationsEntityFramework_AspNetCore.DBContext.Interfaces;

public interface IEntityFrameworkDBContext
{
    DbSet<EntityFrameworkRecord> EntityFrameworkRecords { get; set; }

    EntityEntry Entry(object entity);
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
