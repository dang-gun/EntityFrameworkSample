﻿// <auto-generated />
using System;
using EntityFrameworkSample.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkSample.DB.Migrations.Mariadb
{
    [DbContext(typeof(ModelsDbContext_Mariadb))]
    [Migration("20240208065359_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityFrameworkSample.DB.Models.TestOC1", b =>
                {
                    b.Property<int>("idTestOC1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Int")
                        .HasColumnType("int");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("char(36)");

                    b.HasKey("idTestOC1");

                    b.ToTable("TestOC1");

                    b.HasData(
                        new
                        {
                            idTestOC1 = 1,
                            Int = 1,
                            Str = "str 1",
                            Version = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("EntityFrameworkSample.DB.Models.TestOC2", b =>
                {
                    b.Property<int>("idTestOC2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Int")
                        .HasColumnType("int");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime?>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.HasKey("idTestOC2");

                    b.ToTable("TestOC2");

                    b.HasData(
                        new
                        {
                            idTestOC2 = 1,
                            Int = 2,
                            Str = "str 2"
                        },
                        new
                        {
                            idTestOC2 = 2,
                            Int = 22,
                            Str = "str 22"
                        });
                });

            modelBuilder.Entity("EntityFrameworkSample.DB.Models.TestOC3", b =>
                {
                    b.Property<int>("idTestOC3")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Int")
                        .HasColumnType("int");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("idTestOC3");

                    b.ToTable("TestOC3");

                    b.HasData(
                        new
                        {
                            idTestOC3 = 1,
                            Int = 3,
                            Str = "str 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
