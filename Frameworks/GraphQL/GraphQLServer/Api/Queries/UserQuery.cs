using GraphQLServer.Shema;

namespace GraphQLServer.Api.Queries;

public class UserQuery
{
    //[UsePaging]
    //[UseProjection]
    //[UseFiltering]
    //[UseSorting]
    //public IQueryable<User> GetUsers([Service] AppDbContext context)
    //{
    //    return context.Products;
    //}

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public List<User> GetUsers()
    {
        var users = GetDatabaseUsers();
        return users;
    }

    private List<User> GetDatabaseUsers()
    {
        return
        [
            new User { Id = 1, Name = "Alice", Age = 30, CreatedAt = DateTime.UtcNow },
            new User { Id = 2, Name = "Bob", Age = 25, CreatedAt = DateTime.UtcNow },
            new User { Id = 3, Name = "Charlie", Age = 35, CreatedAt = DateTime.UtcNow }
        ];
    }
}
