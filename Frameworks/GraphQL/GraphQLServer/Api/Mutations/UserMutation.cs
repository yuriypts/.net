using GraphQLServer.Shema;

namespace GraphQLServer.Api.Mutations;

public class UserMutation
{
    //public async Task<User> CreateUser(string name, int age, [Service] AppDbContext context)
    //{
    //    var newUser = new User
    //    {
    //        Id = Guid.NewGuid(),
    //        Name = name,
    //        Age = age,
    //        CreatedAt = DateTime.Now
    //    };

    //    context.Users.Add(newUser);
    //    await context.SaveChangesAsync();

    //    return newUser;
    //}
    
    public async Task<User> CreateUser(string name, int age)
    {
        var newUser = new User
        {
            Id = 10,
            Name = name,
            Age = age,
            CreatedAt = DateTime.Now
        };

        return newUser;
    }
}
