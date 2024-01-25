﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelsDB;

#nullable disable

namespace DynamicOrderBy.Migrations.Sqlite
{
    [DbContext(typeof(ModelsDbContext_Sqlite))]
    partial class ModelsDbContext_SqliteModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.20");

            modelBuilder.Entity("ModelsDB.TestOrderBy", b =>
                {
                    b.Property<int>("idTestOrderBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Int")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idTestOrderBy");

                    b.ToTable("TestOrderBy");
                });

            modelBuilder.Entity("ModelsDB.TestOrderBy_Big", b =>
                {
                    b.Property<int>("idTestOrderBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Int")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idTestOrderBy");

                    b.ToTable("TestOrderBy_Big");
                });
#pragma warning restore 612, 618
        }
    }
}
