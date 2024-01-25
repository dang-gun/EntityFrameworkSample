using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListField.Migrations.Mssql
{
    public partial class EfList_Test2_Edit004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EfList_Test2",
                columns: new[] { "idEfList_Test2", "ListJson1", "ListString1", "ListString2" },
                values: new object[] { 2, "[{\"id\":1,\"Name\":\"test\",\"Age\":10}]", "a,b,c", "a,b,c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EfList_Test2",
                keyColumn: "idEfList_Test2",
                keyValue: 2);
        }
    }
}
