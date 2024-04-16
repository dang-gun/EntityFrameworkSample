﻿// <auto-generated />
using System;
using EntityFrameworkSample.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForeignKeySpeedTest.Migrations.Sqlite
{
    [DbContext(typeof(ModelsDbContext_Sqlite))]
    partial class ModelsDbContext_SqliteModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.20");

            modelBuilder.Entity("ForeignKeySpeedTest.TableModels.ForeignKeyTest1_Blog", b =>
                {
                    b.Property<long>("idTest1Blog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idTest1Blog");

                    b.ToTable("ForeignKeyTest1_Blog");
                });

            modelBuilder.Entity("ForeignKeySpeedTest.TableModels.ForeignKeyTest1_Post", b =>
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

                    b.ToTable("ForeignKeyTest1_Post");
                });

            modelBuilder.Entity("ForeignKeySpeedTest.TableModels.ForeignKeyTest2_Blog", b =>
                {
                    b.Property<long>("idTest2Blog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idTest2Blog");

                    b.ToTable("ForeignKeyTest2_Blog");
                });

            modelBuilder.Entity("ForeignKeySpeedTest.TableModels.ForeignKeyTest2_Post", b =>
                {
                    b.Property<long>("idTest2Post")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<long?>("ForeignKeyTest2_BlogidTest2Blog")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Int")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("idTest2Blog")
                        .HasColumnType("INTEGER");

                    b.HasKey("idTest2Post");

                    b.HasIndex("ForeignKeyTest2_BlogidTest2Blog");

                    b.ToTable("ForeignKeyTest2_Post");
                });

            modelBuilder.Entity("ForeignKeySpeedTest.TableModels.ForeignKeyTest3_Blog", b =>
                {
                    b.Property<long>("idTest3Blog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idTest3Blog");

                    b.ToTable("ForeignKeyTest3_Blog");
                });

            modelBuilder.Entity("ForeignKeySpeedTest.TableModels.ForeignKeyTest3_Post", b =>
                {
                    b.Property<long>("idTest3Post")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Int")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("idTest3Blog")
                        .HasColumnType("INTEGER");

                    b.HasKey("idTest3Post");

                    b.HasIndex("idTest3Blog");

                    b.ToTable("ForeignKeyTest3_Post");
                });

            modelBuilder.Entity("ForeignKeySpeedTest.TableModels.ForeignKeyTest1_Post", b =>
                {
                    b.HasOne("ForeignKeySpeedTest.TableModels.ForeignKeyTest1_Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("idTest1Blog")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("ForeignKeySpeedTest.TableModels.ForeignKeyTest2_Post", b =>
                {
                    b.HasOne("ForeignKeySpeedTest.TableModels.ForeignKeyTest2_Blog", null)
                        .WithMany("Posts")
                        .HasForeignKey("ForeignKeyTest2_BlogidTest2Blog");
                });

            modelBuilder.Entity("ForeignKeySpeedTest.TableModels.ForeignKeyTest3_Post", b =>
                {
                    b.HasOne("ForeignKeySpeedTest.TableModels.ForeignKeyTest3_Blog", "Blog3")
                        .WithMany("Test3Post")
                        .HasForeignKey("idTest3Blog")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog3");
                });

            modelBuilder.Entity("ForeignKeySpeedTest.TableModels.ForeignKeyTest1_Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("ForeignKeySpeedTest.TableModels.ForeignKeyTest2_Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("ForeignKeySpeedTest.TableModels.ForeignKeyTest3_Blog", b =>
                {
                    b.Navigation("Test3Post");
                });
#pragma warning restore 612, 618
        }
    }
}
