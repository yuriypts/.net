Nuget Packages: 

HotChocolate.AspNetCore
	HotChocolate.AspNetCore is the essential NuGet package for integrating the Hot Chocolate GraphQL server into ASP.NET Core applications, 
	providing middleware to host GraphQL APIs. It allows developers to build schema-first or code-first APIs, supporting features like HTTP POST batching, 
	@defer, @stream, and includes the Banana Cake Pop IDE.

HotChocolate.Data
	HotChocolate.Data is a powerful extension package for the Hot Chocolate GraphQL server in .NET, designed to integrate seamlessly 
	with data-access technologies like Entity Framework Core. It provides out-of-the-box features for filtering, sorting, pagination, and projection 
	(selecting only required fields), significantly optimizing database queries and reducing round trips.


There 3 types, 3 root types: Query, Mutation and Subscription.

1. Query: The Query type is used to define read operations in a GraphQL API. 
It allows clients to request data from the server, and the server responds with the requested data. Queries are typically used for fetching data without modifying it.

1. 2. Mutation: The Mutation type is used to define write operations in a GraphQL API. 
It allows clients to modify data on the server, such as creating, updating, or deleting records. Mutations are typically used for operations that change the state of the data.

1. 3. Subscription: The Subscription type is used to define real-time operations in a GraphQL API.

GraphQL literal - It sits in the GraphQL source text