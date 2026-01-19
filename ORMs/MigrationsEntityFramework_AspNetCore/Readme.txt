Entity Framework (EF) is a powerful, open-source object-relational mapping (ORM) framework developed by Microsoft for .NET applications. 
It allows developers to work with databases using C# or Visual Basic objects (known as "entities") instead of writing raw SQL queries, significantly reducing data-access code. 

Key Concepts
 - Object-Relational Mapping (ORM): This technology creates a layer between object-oriented programming languages (like C#) and relational databases, 
 bridging the gap between objects/classes and database tables/columns. The ORM automatically generates the necessary SQL queries based on changes made to the objects in the application code.
 - Entities: These are plain .NET classes that map to tables in the database. Properties of the class map to columns, and instances of the class map to rows.
 - DbContext: This is a key class in EF that manages the database connection, tracks changes to entities, and persists data to the database.
 - LINQ (Language-Integrated Query): EF uses LINQ to write strongly-typed queries against the database using C# syntax. 
 EF translates these LINQ expressions into the appropriate SQL queries for the specific database system being used.
 - Database Providers: EF Core supports various database systems (SQL Server, SQLite, PostgreSQL, MySQL, Azure Cosmos DB, etc.) through specific providers that handle the translation of LINQ to the correct SQL dialect. 

Core Features
 - Change Tracking: EF automatically keeps track of changes made to the entities after they are queried from the database.
 - Migrations: This feature allows developers to evolve the database schema over time as the .NET model classes change, without losing existing data.
Approaches to Database Interaction: EF supports several development approaches:
 - Code First: Developers write the C# model classes first, and EF generates the database from the code (most common approach).
 - Database First: A conceptual model and corresponding classes are generated from an existing database.
 - Model First: A visual model of the database is created first, and then EF generates both the code and the database. 

Versions
The two primary versions in use today are: 
 - Entity Framework Core (EF Core): The modern, lightweight, cross-platform, and open-source version built for .NET Core and the broader .NET platform. It is the de facto standard for modern .NET application development.
 - Entity Framework 6 (EF 6): An older version that was part of the original .NET Framework. It is still supported but primarily for legacy applications. 

Notes:
 - No need real database to create a migration (based on Snapshot)
 - No need AddDbContext (an alternative way) - dotnet ef database update --startup-project ../Project.csproj --context EntityFrameworkDBContext

Commands
dotnet ef migrations add InitialCreate
dotnet ef migrations list
dotnet ef database update
dotnet ef database update {name} (revert migration)


protected override void Up(MigrationBuilder migrationBuilder)
{
	migrationBuilder.RenameTable(
		name: "DocumentIntegrationPlan",
		schema: "dbo",
		newName: "DocumentOrchestrationPlan",
		newSchema: "dbo");
}

protected override void Down(MigrationBuilder migrationBuilder)
{
	migrationBuilder.RenameTable(
		name: "DocumentOrchestrationPlan",
		schema: "dbo",
		newName: "DocumentIntegrationPlan",
		newSchema: "dbo");
}

Create View
In SQL, a view is a virtual table based on the result-set of an SQL statement.
A view contains rows and columns, just like a real table. The fields in a view are fields from one or more real tables in the database.

CREATE VIEW ViewRecord AS SELECT efr.Name FROM EntityFrameworkRecord as efr
DROP VIEW ViewRecord