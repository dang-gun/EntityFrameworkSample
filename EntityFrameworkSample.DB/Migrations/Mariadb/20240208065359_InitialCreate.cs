using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkSample.DB.Migrations.Mariadb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestOC1",
                columns: table => new
                {
                    idTestOC1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Int = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Version = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOC1", x => x.idTestOC1);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestOC2",
                columns: table => new
                {
                    idTestOC2 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Int = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOC2", x => x.idTestOC2);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestOC3",
                columns: table => new
                {
                    idTestOC3 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Int = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOC3", x => x.idTestOC3);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TestOC1",
                columns: new[] { "idTestOC1", "Int", "Str", "Version" },
                values: new object[] { 1, 1, "str 1", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "TestOC2",
                columns: new[] { "idTestOC2", "Int", "Str" },
                values: new object[,]
                {
                    { 1, 2, "str 2" },
                    { 2, 22, "str 22" }
                });

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
