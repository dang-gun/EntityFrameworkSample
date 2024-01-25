﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelsDB;

#nullable disable

namespace ListField.Migrations.Mssql
{
    [DbContext(typeof(DbModel_MssqlContext))]
    [Migration("20230117100705_EfList_Test2_Edit002")]
    partial class EfList_Test2_Edit002
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ModelsDB.EfList_Test2", b =>
                {
                    b.Property<int>("idEfList_Test2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEfList_Test2"), 1L, 1);

                    b.Property<string>("ListJson1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ListString1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ListString2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idEfList_Test2");

                    b.ToTable("EfList_Test2");

                    b.HasData(
                        new
                        {
                            idEfList_Test2 = 1,
                            ListJson1 = "[{\"id\":1,\"Name\":\"test\",\"Age\":10}]",
                            ListString1 = "a,b,c",
                            ListString2 = "a,b,c"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
