Dapper                     - (lightweight ORM) is a simple micro-ORM used to simplify working with ADO.NET; if you like SQL but dislike the boilerplate of ADO.NET: Dapper is for you!
Microsoft.Data.SqlClient   - SQL Server provider (use Npgsql if PostgreSQL, MySqlConnector for MySQL, etc.)


SQL Injectons - you should not use SqlParameter directly with Dapper in most cases. 
Dapper already parameterizes queries internally and protects against SQL injection when you pass parameters as objects.
However, you can use explicit parameters (SqlParameter or DynamicParameters) when you need more control (types, TVP, output params, null handling, etc.).

Common SQL Injection Mistake
Never do: var sql = $"SELECT * FROM Customers WHERE Id = {id}";
or "WHERE Name = '" + name + "'"

That bypasses parameterization.

⭐ Architecture Recommendation (Important)
In your repository layer:
 - simple queries → anonymous object
 - complex queries → DynamicParameters
 - stored procedures → DynamicParameters
 - bulk / TVP → SqlParameter

That keeps code clean and safe.