GraphQL - is a query language for API (Application programing interface), developed by Facebook back in 2012
uses - Facebook, GitHub, Shopify, Twitter etc...

GraphQL literal - It sits in the GraphQL source text

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


Key differences between REST and GraphQL
 - Data fetching (strong and unique path - which return fixed data)
 - Over-fetching and under-fetching (GraphQL allows clients to specify exactly what data they need, avoiding over-fetching and under-fetching issues common in REST APIs)
 - Versioning (GraphQL APIs typically do not require versioning, as clients can request only the fields they need, while REST APIs often require versioning to manage changes in the API structure)
 - Tooling and instrumentation (GraphQL provides more granular control over data fetching and can be more efficient in terms of network usage, while REST APIs may require multiple round trips to fetch related data)