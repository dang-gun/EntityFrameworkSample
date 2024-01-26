using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    public partial class Test3Blog_Add4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Blog1idTest1Blog",
                table: "Test3Post",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "idTest1Blog",
                table: "Test3Post",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Test3Post_Blog1idTest1Blog",
                table: "Test3Post",
                column: "Blog1idTest1Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test1Blog_Blog1idTest1Blog",
                table: "Test3Post",
                column: "Blog1idTest1Blog",
                principalTable: "Test1Blog",
                principalColumn: "idTest1Blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test1Blog_Blog1idTest1Blog",
                table: "Test3Post");

            migrationBuilder.DropIndex(
                name: "IX_Test3Post_Blog1idTest1Blog",
                table: "Test3Post");

            migrationBuilder.DropColumn(
                name: "Blog1idTest1Blog",
                table: "Test3Post");

            migrationBuilder.DropColumn(
                name: "idTest1Blog",
                table: "Test3Post");
        }
    }
}
