using GraphQLServer.DbContext;
using GraphQLServer.Shema;
using GreenDonut.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServer.Api.Queries;

[ExtendObjectType("Query")]
public class UserQuery
{
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<DbPerson> GetUsersIQueryableWithQuery(
        PagingArguments pagingArguments,
        QueryContext<DbPerson> query,
        GraphQLDbContext context)
    {
        var person = context.DbPerson.With(query);
        return person;
    }

    public IQueryable<DbPerson> GetUsersIQueryable([Service] GraphQLDbContext context)
    {
        var person = context.DbPerson;
        return person;
    }

    public async Task<List<DbPerson>> GetUsersList([Service] GraphQLDbContext context)
    {
        var person = await context.DbPerson.ToListAsync();
        return person;
    }

    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public List<User> GetUsers()
    {
        var users = GetDatabaseUsers();
        return users;
    }

    public User? GetUserById(int id)
    {
        var users = GetDatabaseUsers();
        return users.FirstOrDefault(x => x.Id == id);
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
