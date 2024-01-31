﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelsDB;

#nullable disable

namespace MultiMigrations.Migrations.Mssql
{
    [DbContext(typeof(ModelsDbContext_Mssql))]
    partial class ModelsDbContext_MssqlModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ModelsDB.Test1Model", b =>
                {
                    b.Property<long>("idTest1Model")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("idTest1Model"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Int")
                        .HasColumnType("int");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idTest1Model");

                    b.ToTable("Test1Model");

                    b.HasData(
                        new
                        {
                            idTest1Model = 1L,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Int = 1,
                            Str = "Test"
                        });
                });

            modelBuilder.Entity("ModelsDB.Test2Model", b =>
                {
                    b.Property<long>("idTest2Model")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("idTest2Model"), 1L, 1);

                    b.Property<long>("idTest1Model")
                        .HasColumnType("bigint");

                    b.HasKey("idTest2Model");

                    b.HasIndex("idTest1Model");

                    b.ToTable("Test2Model");

                    b.HasData(
                        new
                        {
                            idTest2Model = 1L,
                            idTest1Model = 1L
                        });
                });

            modelBuilder.Entity("ModelsDB.Test2Model", b =>
                {
                    b.HasOne("ModelsDB.Test1Model", "Test1Model")
                        .WithMany("Test2ModelList")
                        .HasForeignKey("idTest1Model")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test1Model");
                });

            modelBuilder.Entity("ModelsDB.Test1Model", b =>
                {
                    b.Navigation("Test2ModelList");
                });
#pragma warning restore 612, 618
        }
    }
}
