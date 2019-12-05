using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCodeFirst.Migrations
{
    public partial class TestUserInfo생성 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "TestUser");

            migrationBuilder.AddColumn<int>(
                name: "Lv",
                table: "TestUserInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "TestUserInfo",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lv",
                table: "TestUserInfo");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "TestUserInfo");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "TestUser",
                nullable: true);
        }
    }
}
