using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    public partial class Test3Blog_Add14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test1Blog_BlogidTest1Blog",
                table: "Test3Post");

            migrationBuilder.DropIndex(
                name: "IX_Test3Post_BlogidTest1Blog",
                table: "Test3Post");

            migrationBuilder.DropColumn(
                name: "BlogidTest1Blog",
                table: "Test3Post");

            migrationBuilder.CreateIndex(
                name: "IX_Test3Post_idTest1Blog",
                table: "Test3Post",
                column: "idTest1Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test1Blog_idTest1Blog",
                table: "Test3Post",
                column: "idTest1Blog",
                principalTable: "Test1Blog",
                principalColumn: "idTest1Blog",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test1Blog_idTest1Blog",
                table: "Test3Post");

            migrationBuilder.DropIndex(
                name: "IX_Test3Post_idTest1Blog",
                table: "Test3Post");

            migrationBuilder.AddColumn<long>(
                name: "BlogidTest1Blog",
                table: "Test3Post",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Test3Post_BlogidTest1Blog",
                table: "Test3Post",
                column: "BlogidTest1Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test1Blog_BlogidTest1Blog",
                table: "Test3Post",
                column: "BlogidTest1Blog",
                principalTable: "Test1Blog",
                principalColumn: "idTest1Blog",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
