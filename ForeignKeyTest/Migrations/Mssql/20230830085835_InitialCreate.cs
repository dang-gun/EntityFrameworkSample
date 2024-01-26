using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Mssql
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test1Blog",
                columns: table => new
                {
                    idTest1Blog = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test1Blog", x => x.idTest1Blog);
                });

            migrationBuilder.CreateTable(
                name: "Test2Blog",
                columns: table => new
                {
                    idTest2Blog = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test2Blog", x => x.idTest2Blog);
                });

            migrationBuilder.CreateTable(
                name: "Test1Post",
                columns: table => new
                {
                    idTest1Post = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Int = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idTest1Blog = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test1Post", x => x.idTest1Post);
                    table.ForeignKey(
                        name: "FK_Test1Post_Test1Blog_idTest1Blog",
                        column: x => x.idTest1Blog,
                        principalTable: "Test1Blog",
                        principalColumn: "idTest1Blog",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test2Post",
                columns: table => new
                {
                    idTest2Post = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Int = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idTest2Blog = table.Column<long>(type: "bigint", nullable: false),
                    Test2BlogidTest2Blog = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test2Post", x => x.idTest2Post);
                    table.ForeignKey(
                        name: "FK_Test2Post_Test2Blog_Test2BlogidTest2Blog",
                        column: x => x.Test2BlogidTest2Blog,
                        principalTable: "Test2Blog",
                        principalColumn: "idTest2Blog");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Test1Post_idTest1Blog",
                table: "Test1Post",
                column: "idTest1Blog");

            migrationBuilder.CreateIndex(
                name: "IX_Test2Post_Test2BlogidTest2Blog",
                table: "Test2Post",
                column: "Test2BlogidTest2Blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test1Post");

            migrationBuilder.DropTable(
                name: "Test2Post");

            migrationBuilder.DropTable(
                name: "Test1Blog");

            migrationBuilder.DropTable(
                name: "Test2Blog");
        }
    }
}
