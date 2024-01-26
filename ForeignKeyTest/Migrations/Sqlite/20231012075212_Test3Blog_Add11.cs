using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    public partial class Test3Blog_Add11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test1Blog_BlogidTest1Blog",
                table: "Test3Post");

            migrationBuilder.AlterColumn<long>(
                name: "idTest1Blog",
                table: "Test3Post",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BlogidTest1Blog",
                table: "Test3Post",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<long>(
                name: "idTest1Blog",
                table: "Test3Post",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<long>(
                name: "BlogidTest1Blog",
                table: "Test3Post",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test1Blog_BlogidTest1Blog",
                table: "Test3Post",
                column: "BlogidTest1Blog",
                principalTable: "Test1Blog",
                principalColumn: "idTest1Blog");
        }
    }
}
