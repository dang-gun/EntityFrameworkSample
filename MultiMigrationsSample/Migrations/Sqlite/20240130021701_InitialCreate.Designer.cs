﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelsDB;

#nullable disable

namespace MultiMigrationsSample.Migrations.Sqlite
{
    [DbContext(typeof(DbModel_SqliteContext))]
    [Migration("20240130021701_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.20");

            modelBuilder.Entity("ModelsDB.DbData1Model", b =>
                {
                    b.Property<int>("idDbData1Model")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idDbData1Model");

                    b.ToTable("DbData1Model");

                    b.HasData(
                        new
                        {
                            idDbData1Model = 1,
                            Age = 1,
                            Name = "Test"
                        });
                });

            modelBuilder.Entity("ModelsDB.DbData2Model", b =>
                {
                    b.Property<int>("idDbData2Model")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idDbData2Model");

                    b.ToTable("DbData2Model");

                    b.HasData(
                        new
                        {
                            idDbData2Model = 1,
                            FirstName = "T",
                            LastName = "est"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
