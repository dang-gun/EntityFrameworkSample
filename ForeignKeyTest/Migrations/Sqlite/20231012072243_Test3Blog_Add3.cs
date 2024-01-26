using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    public partial class Test3Blog_Add3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test3Blog",
                columns: table => new
                {
                    idTest3Blog = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test3Blog", x => x.idTest3Blog);
                });

            migrationBuilder.CreateTable(
                name: "Test3Post",
                columns: table => new
                {
                    idTest1Post = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    idTest3Blog = table.Column<long>(type: "INTEGER", nullable: false),
                    BlogidTest3Blog = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test3Post", x => x.idTest1Post);
                    table.ForeignKey(
                        name: "FK_Test3Post_Test3Blog_BlogidTest3Blog",
                        column: x => x.BlogidTest3Blog,
                        principalTable: "Test3Blog",
                        principalColumn: "idTest3Blog");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Test3Post_BlogidTest3Blog",
                table: "Test3Post",
                column: "BlogidTest3Blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test3Post");

            migrationBuilder.DropTable(
                name: "Test3Blog");
        }
    }
}
