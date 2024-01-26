using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    public partial class Test3Blog_Edit002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "idTest3Post",
                table: "Test3Post",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Test3Post_Test3Blog_idTest3Post",
                table: "Test3Post",
                column: "idTest3Post",
                principalTable: "Test3Blog",
                principalColumn: "idTest3Blog",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
