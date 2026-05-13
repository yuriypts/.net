
using GraphQLServer.Api.Mutations;
using GraphQLServer.Api.Queries;

namespace GraphQLServer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services
            .AddGraphQLServer()
            .AddQueryType<UserQuery>()
            .AddMutationType<UserMutation>()
            .AddProjections()
            .AddFiltering()
            .AddSorting();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGraphQL();

        app.Run();
    }
}
