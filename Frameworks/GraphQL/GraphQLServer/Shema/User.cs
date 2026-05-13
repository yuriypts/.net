namespace GraphQLServer.Shema;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public int Age { get; set; }

    public DateTime CreatedAt { get; set; }
}
