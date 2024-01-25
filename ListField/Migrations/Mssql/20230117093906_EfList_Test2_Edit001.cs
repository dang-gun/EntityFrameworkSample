using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListField.Migrations.Mssql
{
    public partial class EfList_Test2_Edit001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ListString2",
                table: "EfList_Test2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "EfList_Test2",
                keyColumn: "idEfList_Test2",
                keyValue: 1,
                column: "ListString2",
                value: "a,b,c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListString2",
                table: "EfList_Test2");
        }
    }
}
