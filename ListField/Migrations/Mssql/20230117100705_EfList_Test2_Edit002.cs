using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListField.Migrations.Mssql
{
    public partial class EfList_Test2_Edit002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ListJson1",
                table: "EfList_Test2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "EfList_Test2",
                keyColumn: "idEfList_Test2",
                keyValue: 1,
                column: "ListJson1",
                value: "[{\"id\":1,\"Name\":\"test\",\"Age\":10}]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListJson1",
                table: "EfList_Test2");
        }
    }
}
