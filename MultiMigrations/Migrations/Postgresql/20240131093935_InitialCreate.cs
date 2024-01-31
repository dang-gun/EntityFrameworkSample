﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MultiMigrations.Migrations.Postgresql
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test1Model",
                columns: table => new
                {
                    idTest1Model = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Int = table.Column<int>(type: "integer", nullable: false),
                    Str = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test1Model", x => x.idTest1Model);
                });

            migrationBuilder.CreateTable(
                name: "Test2Model",
                columns: table => new
                {
                    idTest2Model = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idTest1Model = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test2Model", x => x.idTest2Model);
                    table.ForeignKey(
                        name: "FK_Test2Model_Test1Model_idTest1Model",
                        column: x => x.idTest1Model,
                        principalTable: "Test1Model",
                        principalColumn: "idTest1Model",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Test1Model",
                columns: new[] { "idTest1Model", "Date", "Int", "Str" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Test" });

            migrationBuilder.InsertData(
                table: "Test2Model",
                columns: new[] { "idTest2Model", "idTest1Model" },
                values: new object[] { 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Test2Model_idTest1Model",
                table: "Test2Model",
                column: "idTest1Model");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test2Model");

            migrationBuilder.DropTable(
                name: "Test1Model");
        }
    }
}
