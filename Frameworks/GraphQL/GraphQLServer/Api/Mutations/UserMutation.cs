using GraphQLServer.Api.Subscriptions;
using GraphQLServer.DbContext;
using GraphQLServer.Shema;
using HotChocolate.Subscriptions;

namespace GraphQLServer.Api.Mutations;

public record DbPersonPayload(string Name);

[ExtendObjectType("Mutation")]
public class UserMutation
{
    public async Task<DbPerson> CreateDatabaseUser(DbPersonPayload payload, [Service] GraphQLDbContext context)
    {
        if (string.IsNullOrEmpty(payload.Name))
        {
            throw new ArgumentException("Invalid user data");
        }

        var newUser = new DbPerson
        {
            Id = Guid.NewGuid(),
            Name = payload.Name
        };

        context.DbPerson.Add(newUser);
        //await context.SaveChangesAsync();

        return newUser;
    }

    public async Task<User> CreateUser(string name, int age, [Service] ITopicEventSender topicEventSender)
    {
        var newUser = new User
        {
            Id = 10,
            Name = name,
            Age = age,
            CreatedAt = DateTime.Now
        };

        await topicEventSender.SendAsync(nameof(PersionSubscription.OnPersonCreated), newUser.Name);

        return newUser;
    }
}
