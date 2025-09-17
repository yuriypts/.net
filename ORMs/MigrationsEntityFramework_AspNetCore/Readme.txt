Notes:
 - No need real database to create a migration (based on Snapshot)
 - No need AddDbContext (an alternative way) - dotnet ef database update --startup-project ../Project.csproj --context EntityFrameworkDBContext

Commands
dotnet ef migrations add InitialCreate
dotnet ef migrations list
dotnet ef database update


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