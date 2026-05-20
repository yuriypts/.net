namespace GraphQLServer.Api.Subscriptions;

[ExtendObjectType("Subscription")]
public class PersionSubscription
{
    [Subscribe]
    [Topic]
    public string OnPersonCreated([EventMessage] string name)
    {
        return $"Person created: {name}";
    }
}
