using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForeignKeyTest1_Blog",
                columns: table => new
                {
                    idTest1Blog = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignKeyTest1_Blog", x => x.idTest1Blog);
                });

            migrationBuilder.CreateTable(
                name: "ForeignKeyTest2_Blog",
                columns: table => new
                {
                    idTest2Blog = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignKeyTest2_Blog", x => x.idTest2Blog);
                });

            migrationBuilder.CreateTable(
                name: "ForeignKeyTest3_Blog",
                columns: table => new
                {
                    idTest3Blog = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignKeyTest3_Blog", x => x.idTest3Blog);
                });

            migrationBuilder.CreateTable(
                name: "ForeignKeyTest1_Post",
                columns: table => new
                {
                    idTest1Post = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    idTest1Blog = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignKeyTest1_Post", x => x.idTest1Post);
                    table.ForeignKey(
                        name: "FK_ForeignKeyTest1_Post_ForeignKeyTest1_Blog_idTest1Blog",
                        column: x => x.idTest1Blog,
                        principalTable: "ForeignKeyTest1_Blog",
                        principalColumn: "idTest1Blog",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForeignKeyTest2_Post",
                columns: table => new
                {
                    idTest2Post = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    idTest2Blog = table.Column<long>(type: "INTEGER", nullable: false),
                    ForeignKeyTest2_BlogidTest2Blog = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignKeyTest2_Post", x => x.idTest2Post);
                    table.ForeignKey(
                        name: "FK_ForeignKeyTest2_Post_ForeignKeyTest2_Blog_ForeignKeyTest2_BlogidTest2Blog",
                        column: x => x.ForeignKeyTest2_BlogidTest2Blog,
                        principalTable: "ForeignKeyTest2_Blog",
                        principalColumn: "idTest2Blog");
                });

            migrationBuilder.CreateTable(
                name: "ForeignKeyTest3_Post",
                columns: table => new
                {
                    idTest3Post = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Int = table.Column<int>(type: "INTEGER", nullable: false),
                    Str = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    idTest3Blog = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignKeyTest3_Post", x => x.idTest3Post);
                    table.ForeignKey(
                        name: "FK_ForeignKeyTest3_Post_ForeignKeyTest3_Blog_idTest3Blog",
                        column: x => x.idTest3Blog,
                        principalTable: "ForeignKeyTest3_Blog",
                        principalColumn: "idTest3Blog",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForeignKeyTest1_Post_idTest1Blog",
                table: "ForeignKeyTest1_Post",
                column: "idTest1Blog");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignKeyTest2_Post_ForeignKeyTest2_BlogidTest2Blog",
                table: "ForeignKeyTest2_Post",
                column: "ForeignKeyTest2_BlogidTest2Blog");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignKeyTest3_Post_idTest3Blog",
                table: "ForeignKeyTest3_Post",
                column: "idTest3Blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForeignKeyTest1_Post");

            migrationBuilder.DropTable(
                name: "ForeignKeyTest2_Post");

            migrationBuilder.DropTable(
                name: "ForeignKeyTest3_Post");

            migrationBuilder.DropTable(
                name: "ForeignKeyTest1_Blog");

            migrationBuilder.DropTable(
                name: "ForeignKeyTest2_Blog");

            migrationBuilder.DropTable(
                name: "ForeignKeyTest3_Blog");
        }
    }
}
