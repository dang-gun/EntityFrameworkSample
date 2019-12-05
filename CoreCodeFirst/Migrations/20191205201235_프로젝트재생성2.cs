using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCodeFirst.Migrations
{
    public partial class 프로젝트재생성2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Money",
                table: "TestUserInfo",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Money",
                table: "TestUserInfo");
        }
    }
}
