using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCodeFirst.Migrations
{
    public partial class TestUser_에_Message_추가 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "TestUser",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "TestUser");
        }
    }
}
