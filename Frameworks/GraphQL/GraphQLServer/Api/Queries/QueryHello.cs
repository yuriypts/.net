namespace GraphQLServer.Api.Queries;

[ExtendObjectType("Query")]
public class QueryHello
{
    public string Hello(string name = "World") => $"Hello, {name}";

    public Person GetPerson()
    {
        return new Person("Test", new Profession("Programer"));
    }
}

public record Person(string Name, Profession profesion);

public record Profession(string Name);
