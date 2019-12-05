using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCodeFirst.Migrations
{
    public partial class FK_Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestUserInfo",
                columns: table => new
                {
                    idTestUserInfo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idTestUserForeignKey = table.Column<long>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_TestUserInfo_idTestUserForeignKey",
                table: "TestUserInfo",
                column: "idTestUserForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestUserInfo");
        }
    }
}
