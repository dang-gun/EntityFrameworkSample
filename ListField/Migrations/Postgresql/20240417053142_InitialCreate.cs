using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ListField.Migrations.Postgresql
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EfList_Test2",
                columns: table => new
                {
                    idEfList_Test2 = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListString1 = table.Column<string>(type: "text", nullable: false),
                    ListString2 = table.Column<string>(type: "text", nullable: false),
                    ListJson1 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EfList_Test2", x => x.idEfList_Test2);
                });

            migrationBuilder.InsertData(
                table: "EfList_Test2",
                columns: new[] { "idEfList_Test2", "ListJson1", "ListString1", "ListString2" },
                values: new object[,]
                {
                    { 1, "[{\"id\":1,\"Name\":\"test1\",\"Age\":11}]", "a11,b11,c11", "a12,b12,c12" },
                    { 2, "[{\"id\":1,\"Name\":\"test2\",\"Age\":12}]", "a21,b21,c21", "a22,b22,c22" },
                    { 3, "[{\"id\":3,\"Name\":\"test3\",\"Age\":13}]", "a31,b31,c31", "a32,b32,c32" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EfList_Test2");
        }
    }
}
