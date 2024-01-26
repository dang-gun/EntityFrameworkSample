using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    public partial class Test3Blog_Add13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test1Blog_idTest3Blog",
                table: "Test3Post");

            migrationBuilder.RenameColumn(
                name: "idTest3Blog",
                table: "Test3Post",
                newName: "BlogidTest1Blog");

            migrationBuilder.RenameIndex(
                name: "IX_Test3Post_idTest3Blog",
                table: "Test3Post",
                newName: "IX_Test3Post_BlogidTest1Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test1Blog_BlogidTest1Blog",
                table: "Test3Post",
                column: "BlogidTest1Blog",
                principalTable: "Test1Blog",
                principalColumn: "idTest1Blog",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test1Blog_BlogidTest1Blog",
                table: "Test3Post");

            migrationBuilder.RenameColumn(
                name: "BlogidTest1Blog",
                table: "Test3Post",
                newName: "idTest3Blog");

            migrationBuilder.RenameIndex(
                name: "IX_Test3Post_BlogidTest1Blog",
                table: "Test3Post",
                newName: "IX_Test3Post_idTest3Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test1Blog_idTest3Blog",
                table: "Test3Post",
                column: "idTest3Blog",
                principalTable: "Test1Blog",
                principalColumn: "idTest1Blog",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
