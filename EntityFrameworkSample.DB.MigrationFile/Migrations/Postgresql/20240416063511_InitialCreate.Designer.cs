﻿// <auto-generated />
using EntityFrameworkSample.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityFrameworkSample.DB.MigrationFile.Migrations.Postgresql
{
    [DbContext(typeof(ModelsDbContext_Postgresql))]
    [Migration("20240416063511_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntityFrameworkSample.DB.MigrationFile.TableModels.TestTable", b =>
                {
                    b.Property<int>("idTestTable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idTestTable"));

                    b.Property<int>("Int")
                        .HasColumnType("integer");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("idTestTable");

                    b.ToTable("TestTable");

                    b.HasData(
                        new
                        {
                            idTestTable = -1,
                            Int = 0,
                            Str = "str 0"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
