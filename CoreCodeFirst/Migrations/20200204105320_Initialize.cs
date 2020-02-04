using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCodeFirst.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestUser",
                columns: table => new
                {
                    idTestUser = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    JoinType = table.Column<int>(nullable: false),
                    Money = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUser", x => x.idTestUser);
                });

            migrationBuilder.CreateTable(
                name: "TestUserInfo",
                columns: table => new
                {
                    idTestUserInfo = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idTestUserForeignKey = table.Column<long>(nullable: true),
                    Lv = table.Column<int>(nullable: false),
                    NickName = table.Column<string>(maxLength: 10, nullable: true),
                    Money = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUserInfo", x => x.idTestUserInfo);
                    table.ForeignKey(
                        name: "FK_TestUserInfo_TestUser_idTestUserForeignKey",
                        column: x => x.idTestUserForeignKey,
                        principalTable: "TestUser",
                        principalColumn: "idTestUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TestUser",
                columns: new[] { "idTestUser", "Email", "JoinDate", "JoinType", "Money", "Password" },
                values: new object[] { 1L, "test01@test.com", new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 10.1, "1111" });

            migrationBuilder.InsertData(
                table: "TestUser",
                columns: new[] { "idTestUser", "Email", "JoinDate", "JoinType", "Money", "Password" },
                values: new object[] { 2L, "test02@test.com", new DateTime(2019, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1000.22, "1111" });

            migrationBuilder.CreateIndex(
                name: "IX_TestUserInfo_idTestUserForeignKey",
                table: "TestUserInfo",
                column: "idTestUserForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestUserInfo");

            migrationBuilder.DropTable(
                name: "TestUser");
        }
    }
}
