using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    public partial class Test3Blog_Add8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test3Post");

            migrationBuilder.DropTable(
                name: "Test3Blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    idTest3Post = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Blog3idTest3Blog = table.Column<long>(type: "INTEGER", nullable: true),
                    BlogidTest1Blog = table.Column<long>(type: "INTEGER", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", nullable: false),
                    idTest1Blog = table.Column<long>(type: "INTEGER", nullable: false),
                    idTest3Blog = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test3Post", x => x.idTest3Post);
                    table.ForeignKey(
                        name: "FK_Test3Post_Test1Blog_BlogidTest1Blog",
                        column: x => x.BlogidTest1Blog,
                        principalTable: "Test1Blog",
                        principalColumn: "idTest1Blog");
                    table.ForeignKey(
                        name: "FK_Test3Post_Test3Blog_Blog3idTest3Blog",
                        column: x => x.Blog3idTest3Blog,
                        principalTable: "Test3Blog",
                        principalColumn: "idTest3Blog");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Test3Post_Blog3idTest3Blog",
                table: "Test3Post",
                column: "Blog3idTest3Blog");

            migrationBuilder.CreateIndex(
                name: "IX_Test3Post_BlogidTest1Blog",
                table: "Test3Post",
                column: "BlogidTest1Blog");
        }
    }
}
