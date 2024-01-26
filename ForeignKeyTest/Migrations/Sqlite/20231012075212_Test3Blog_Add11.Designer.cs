﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelsDB;

#nullable disable

namespace ForeignKeyTest.Migrations.Sqlite
{
    [DbContext(typeof(ModelsDbContext_Sqlite))]
    [Migration("20231012075212_Test3Blog_Add11")]
    partial class Test3Blog_Add11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.20");

            modelBuilder.Entity("ModelsDB.Test1Blog", b =>
                {
                    b.Property<long>("idTest1Blog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idTest1Blog");

                    b.ToTable("Test1Blog");
                });

            modelBuilder.Entity("ModelsDB.Test1Post", b =>
                {
                    b.Property<long>("idTest1Post")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Int")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("idTest1Blog")
                        .HasColumnType("INTEGER");

                    b.HasKey("idTest1Post");

                    b.HasIndex("idTest1Blog");

                    b.ToTable("Test1Post");
                });

            modelBuilder.Entity("ModelsDB.Test2Blog", b =>
                {
                    b.Property<long>("idTest2Blog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idTest2Blog");

                    b.ToTable("Test2Blog");
                });

            modelBuilder.Entity("ModelsDB.Test2Post", b =>
                {
                    b.Property<long>("idTest2Post")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Int")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("Test2BlogidTest2Blog")
                        .HasColumnType("INTEGER");

                    b.Property<long>("idTest2Blog")
                        .HasColumnType("INTEGER");

                    b.HasKey("idTest2Post");

                    b.HasIndex("Test2BlogidTest2Blog");

                    b.ToTable("Test2Post");
                });

            modelBuilder.Entity("ModelsDB.Test3Blog.Test3Blog", b =>
                {
                    b.Property<long>("idTest3Blog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idTest3Blog");

                    b.ToTable("Test3Blog");
                });

            modelBuilder.Entity("ModelsDB.Test3Post", b =>
                {
                    b.Property<long>("idTest3Post")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BlogidTest1Blog")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Int")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("idTest1Blog")
                        .HasColumnType("INTEGER");

                    b.HasKey("idTest3Post");

                    b.HasIndex("BlogidTest1Blog");

                    b.ToTable("Test3Post");
                });

            modelBuilder.Entity("ModelsDB.Test1Post", b =>
                {
                    b.HasOne("ModelsDB.Test1Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("idTest1Blog")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("ModelsDB.Test2Post", b =>
                {
                    b.HasOne("ModelsDB.Test2Blog", null)
                        .WithMany("Posts")
                        .HasForeignKey("Test2BlogidTest2Blog");
                });

            modelBuilder.Entity("ModelsDB.Test3Post", b =>
                {
                    b.HasOne("ModelsDB.Test1Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogidTest1Blog")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("ModelsDB.Test1Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("ModelsDB.Test2Blog", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
