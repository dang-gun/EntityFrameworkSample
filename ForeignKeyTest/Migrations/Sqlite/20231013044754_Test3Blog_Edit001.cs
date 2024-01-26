using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    public partial class Test3Blog_Edit001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test1Blog_idTest1Blog",
                table: "Test3Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test1Blog_idTest3Blog",
                table: "Test3Post");

            migrationBuilder.DropIndex(
                name: "IX_Test3Post_idTest1Blog",
                table: "Test3Post");

            migrationBuilder.DropColumn(
                name: "idTest1Blog",
                table: "Test3Post");

            migrationBuilder.AlterColumn<long>(
                name: "idTest3Post",
                table: "Test3Post",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test3Blog_idTest3Blog",
                table: "Test3Post",
                column: "idTest3Blog",
                principalTable: "Test3Blog",
                principalColumn: "idTest3Blog",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test3Blog_idTest3Post",
                table: "Test3Post",
                column: "idTest3Post",
                principalTable: "Test3Blog",
                principalColumn: "idTest3Blog",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test3Blog_idTest3Blog",
                table: "Test3Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Test3Post_Test3Blog_idTest3Post",
                table: "Test3Post");

            migrationBuilder.AlterColumn<long>(
                name: "idTest3Post",
                table: "Test3Post",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<long>(
                name: "idTest1Blog",
                table: "Test3Post",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

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
