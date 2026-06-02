using GraphQLServer.Api.Mutations;
using GraphQLServer.Api.Queries;
using GraphQLServer.Api.Subscriptions;
using GraphQLServer.DbContext;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });

        // Use your actual DbContext type instead of the base DbContext
        builder.Services.AddDbContext<GraphQLDbContext>((serviceProvider, options) =>
        {
            // optional migrations assembly if needed
            //options.UseSqlServer(builder.Configuration.GetConnectionString("DbContextConnectionString"), actions => actions.MigrationsAssembly("ProjectName"));
            options.UseSqlServer(builder.Configuration.GetConnectionString("DbContextConnectionString"));
        });

        // Add services to the container.
        //builder.Services.AddAuthorization();

        // Specify the overload explicitly to resolve ambiguity
        //builder.Services
        //    .AddGraphQLServer()
        //    .AddQueryType<QueryHello>()
        //    .AddMutationType<UserMutation>();

        builder.Services
            .AddGraphQLServer()
            .AddQueryType(x => x.Name("Query"))
            .AddMutationType(x => x.Name("Mutation"))
            .AddSubscriptionType(x => x.Name("Subscription"))
            .AddTypeExtension<QueryHello>()
            .AddTypeExtension<UserQuery>()
            .AddTypeExtension<UserMutation>()
            .AddTypeExtension<PersionSubscription>()
            .AddInMemorySubscriptions()
            .AddProjections()
            .AddFiltering()
            .AddSorting();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGraphQL();

        app.UseCors();

        app.Run();
    }
}
