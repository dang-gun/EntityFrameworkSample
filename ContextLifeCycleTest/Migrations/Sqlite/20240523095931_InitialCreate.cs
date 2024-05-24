using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContextLifeCycleTest.Migrations.Sqlite
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestTable1",
                columns: table => new
                {
                    idTestTable1 = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable1", x => x.idTestTable1);
                });

            migrationBuilder.CreateTable(
                name: "TestTable2",
                columns: table => new
                {
                    idTestTable2 = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable2", x => x.idTestTable2);
                });

            migrationBuilder.CreateTable(
                name: "TestTable3",
                columns: table => new
                {
                    idTestTable3 = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable3", x => x.idTestTable3);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTable1");

            migrationBuilder.DropTable(
                name: "TestTable2");

            migrationBuilder.DropTable(
                name: "TestTable3");
        }
    }
}
