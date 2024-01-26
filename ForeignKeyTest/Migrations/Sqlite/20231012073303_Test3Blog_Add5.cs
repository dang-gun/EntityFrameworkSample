using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    public partial class Test3Blog_Add5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test1Blog_Blog1idTest1Blog",
                table: "Test3Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test3Blog_BlogidTest3Blog",
                table: "Test3Post");

            migrationBuilder.RenameColumn(
                name: "BlogidTest3Blog",
                table: "Test3Post",
                newName: "BlogidTest1Blog");

            migrationBuilder.RenameColumn(
                name: "Blog1idTest1Blog",
                table: "Test3Post",
                newName: "Blog3idTest3Blog");

            migrationBuilder.RenameIndex(
                name: "IX_Test3Post_BlogidTest3Blog",
                table: "Test3Post",
                newName: "IX_Test3Post_BlogidTest1Blog");

            migrationBuilder.RenameIndex(
                name: "IX_Test3Post_Blog1idTest1Blog",
                table: "Test3Post",
                newName: "IX_Test3Post_Blog3idTest3Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test1Blog_BlogidTest1Blog",
                table: "Test3Post",
                column: "BlogidTest1Blog",
                principalTable: "Test1Blog",
                principalColumn: "idTest1Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test3Blog_Blog3idTest3Blog",
                table: "Test3Post",
                column: "Blog3idTest3Blog",
                principalTable: "Test3Blog",
                principalColumn: "idTest3Blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test1Blog_BlogidTest1Blog",
                table: "Test3Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test3Blog_Blog3idTest3Blog",
                table: "Test3Post");

            migrationBuilder.RenameColumn(
                name: "BlogidTest1Blog",
                table: "Test3Post",
                newName: "BlogidTest3Blog");

            migrationBuilder.RenameColumn(
                name: "Blog3idTest3Blog",
                table: "Test3Post",
                newName: "Blog1idTest1Blog");

            migrationBuilder.RenameIndex(
                name: "IX_Test3Post_BlogidTest1Blog",
                table: "Test3Post",
                newName: "IX_Test3Post_BlogidTest3Blog");

            migrationBuilder.RenameIndex(
                name: "IX_Test3Post_Blog3idTest3Blog",
                table: "Test3Post",
                newName: "IX_Test3Post_Blog1idTest1Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test1Blog_Blog1idTest1Blog",
                table: "Test3Post",
                column: "Blog1idTest1Blog",
                principalTable: "Test1Blog",
                principalColumn: "idTest1Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test3Blog_BlogidTest3Blog",
                table: "Test3Post",
                column: "BlogidTest3Blog",
                principalTable: "Test3Blog",
                principalColumn: "idTest3Blog");
        }
    }
}
