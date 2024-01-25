using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicOrderBy.Migrations.Sqlite
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestOrderBy",
                columns: table => new
                {
                    idTestOrderBy = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOrderBy", x => x.idTestOrderBy);
                });

            migrationBuilder.CreateTable(
                name: "TestOrderBy_Big",
                columns: table => new
                {
                    idTestOrderBy = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOrderBy_Big", x => x.idTestOrderBy);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestOrderBy");

            migrationBuilder.DropTable(
                name: "TestOrderBy_Big");
        }
    }
}
