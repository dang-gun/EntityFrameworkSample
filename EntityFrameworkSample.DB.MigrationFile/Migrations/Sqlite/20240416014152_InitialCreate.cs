using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkSample.DB.MigrationFile.Migrations.Sqlite
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestTable",
                columns: table => new
                {
                    idTestTable = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable", x => x.idTestTable);
                });

            migrationBuilder.InsertData(
                table: "TestTable",
                columns: new[] { "idTestTable", "Int", "Str" },
                values: new object[] { -1, 0, "str 0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTable");
        }
    }
}
