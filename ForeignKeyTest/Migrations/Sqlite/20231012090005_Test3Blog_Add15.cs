using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    public partial class Test3Blog_Add15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "idTest3Blog",
                table: "Test3Post",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Test3Post_idTest3Blog",
                table: "Test3Post",
                column: "idTest3Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test1Blog_idTest3Blog",
                table: "Test3Post",
                column: "idTest3Blog",
                principalTable: "Test1Blog",
                principalColumn: "idTest1Blog",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test1Blog_idTest3Blog",
                table: "Test3Post");

            migrationBuilder.DropIndex(
                name: "IX_Test3Post_idTest3Blog",
                table: "Test3Post");

            migrationBuilder.DropColumn(
                name: "idTest3Blog",
                table: "Test3Post");
        }
    }
}
