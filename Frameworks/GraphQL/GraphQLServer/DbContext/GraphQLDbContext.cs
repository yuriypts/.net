using Microsoft.EntityFrameworkCore;

namespace GraphQLServer.DbContext;

public class DbPerson
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class GraphQLDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<DbPerson> DbPerson { get; set; } = default!;

    public GraphQLDbContext()
    {
    }

    public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options)
    {
    }
}
