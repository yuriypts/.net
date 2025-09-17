Notes:
 - No need real database to create a migration (based on Snapshot)

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