using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptimisticConcurrencyTest.Migrations.Sqlite
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestOC1",
                columns: table => new
                {
                    idTestOC1 = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Version = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOC1", x => x.idTestOC1);
                });

            migrationBuilder.CreateTable(
                name: "TestOC2",
                columns: table => new
                {
                    idTestOC2 = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Version = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOC2", x => x.idTestOC2);
                });

            migrationBuilder.CreateTable(
                name: "TestOC3",
                columns: table => new
                {
                    idTestOC3 = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOC3", x => x.idTestOC3);
                });

            migrationBuilder.InsertData(
                table: "TestOC1",
                columns: new[] { "idTestOC1", "Int", "Str", "Version" },
                values: new object[] { 1, 1, "str 1", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "TestOC2",
                columns: new[] { "idTestOC2", "Int", "Str" },
                values: new object[] { 1, 2, "str 2" });

            migrationBuilder.InsertData(
                table: "TestOC2",
                columns: new[] { "idTestOC2", "Int", "Str" },
                values: new object[] { 2, 22, "str 22" });

            migrationBuilder.InsertData(
                table: "TestOC3",
                columns: new[] { "idTestOC3", "Int", "Str" },
                values: new object[] { 1, 3, "str 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestOC1");

            migrationBuilder.DropTable(
                name: "TestOC2");

            migrationBuilder.DropTable(
                name: "TestOC3");
        }
    }
}
