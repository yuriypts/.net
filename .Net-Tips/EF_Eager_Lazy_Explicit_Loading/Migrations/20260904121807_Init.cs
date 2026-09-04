using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Eager_Lazy_Explicit_Loading.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoftwareEngineer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareEngineer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftwareEngineerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_SoftwareEngineer_SoftwareEngineerId",
                        column: x => x.SoftwareEngineerId,
                        principalTable: "SoftwareEngineer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SoftwareEngineer",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Test1" },
                    { 2, "Test2" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "SoftwareEngineerId", "Type" },
                values: new object[,]
                {
                    { 1, 1, "PC" },
                    { 2, 1, "Laptop" },
                    { 3, 2, "Mobile" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_SoftwareEngineerId",
                table: "Devices",
                column: "SoftwareEngineerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "SoftwareEngineer");
        }
    }
}
