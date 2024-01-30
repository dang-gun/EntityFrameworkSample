using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiMigrationsSample.Migrations.Mssql
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbData1Model",
                columns: table => new
                {
                    idDbData1Model = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbData1Model", x => x.idDbData1Model);
                });

            migrationBuilder.CreateTable(
                name: "DbData2Model",
                columns: table => new
                {
                    idDbData2Model = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbData2Model", x => x.idDbData2Model);
                });

            migrationBuilder.InsertData(
                table: "DbData1Model",
                columns: new[] { "idDbData1Model", "Age", "Name" },
                values: new object[] { 1, 1, "Test" });

            migrationBuilder.InsertData(
                table: "DbData2Model",
                columns: new[] { "idDbData2Model", "FirstName", "LastName" },
                values: new object[] { 1, "T", "est" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbData1Model");

            migrationBuilder.DropTable(
                name: "DbData2Model");
        }
    }
}
