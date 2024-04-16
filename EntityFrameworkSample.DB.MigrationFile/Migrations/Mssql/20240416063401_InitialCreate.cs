using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkSample.DB.MigrationFile.Migrations.Mssql
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestTable",
                columns: table => new
                {
                    idTestTable = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Int = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
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
