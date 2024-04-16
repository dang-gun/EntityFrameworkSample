using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeignKeyTest.Migrations.Mssql
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoIncreases_Test1",
                columns: table => new
                {
                    idAutoIncreases_Test1 = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoIncreases_Test1", x => x.idAutoIncreases_Test1);
                });

            migrationBuilder.CreateTable(
                name: "AutoIncreases_Test2",
                columns: table => new
                {
                    idAutoIncreases_Test2 = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idAutoIncreases_Test1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoIncreases_Test2", x => x.idAutoIncreases_Test2);
                    table.ForeignKey(
                        name: "FK_AutoIncreases_Test2_AutoIncreases_Test1_idAutoIncreases_Test1",
                        column: x => x.idAutoIncreases_Test1,
                        principalTable: "AutoIncreases_Test1",
                        principalColumn: "idAutoIncreases_Test1",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoIncreases_Test3",
                columns: table => new
                {
                    idAutoIncreases_Test3 = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idAutoIncreases_Test1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoIncreases_Test3", x => x.idAutoIncreases_Test3);
                    table.ForeignKey(
                        name: "FK_AutoIncreases_Test3_AutoIncreases_Test1_idAutoIncreases_Test1",
                        column: x => x.idAutoIncreases_Test1,
                        principalTable: "AutoIncreases_Test1",
                        principalColumn: "idAutoIncreases_Test1",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AutoIncreases_Test1",
                columns: new[] { "idAutoIncreases_Test1", "Name" },
                values: new object[] { 1L, "Test" });

            migrationBuilder.CreateIndex(
                name: "IX_AutoIncreases_Test2_idAutoIncreases_Test1",
                table: "AutoIncreases_Test2",
                column: "idAutoIncreases_Test1");

            migrationBuilder.CreateIndex(
                name: "IX_AutoIncreases_Test3_idAutoIncreases_Test1",
                table: "AutoIncreases_Test3",
                column: "idAutoIncreases_Test1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoIncreases_Test2");

            migrationBuilder.DropTable(
                name: "AutoIncreases_Test3");

            migrationBuilder.DropTable(
                name: "AutoIncreases_Test1");
        }
    }
}
