using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    public partial class Test3Blog_Add6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idTest1Post",
                table: "Test3Post",
                newName: "idTest3Post");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idTest3Post",
                table: "Test3Post",
                newName: "idTest1Post");
        }
    }
}
