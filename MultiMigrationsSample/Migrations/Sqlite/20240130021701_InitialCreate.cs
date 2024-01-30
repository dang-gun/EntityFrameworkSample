using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiMigrationsSample.Migrations.Sqlite
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbData1Model",
                columns: table => new
                {
                    idDbData1Model = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbData1Model", x => x.idDbData1Model);
                });

            migrationBuilder.CreateTable(
                name: "DbData2Model",
                columns: table => new
                {
                    idDbData2Model = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
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
