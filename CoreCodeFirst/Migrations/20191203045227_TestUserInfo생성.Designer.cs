﻿// <auto-generated />
using System;
using CoreCodeFirst.ModelDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreCodeFirst.Migrations
{
    [DbContext(typeof(CoreCodeFirstContext))]
    [Migration("20191203045227_TestUserInfo생성")]
    partial class TestUserInfo생성
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreCodeFirstSample.ModelDB.TestUser", b =>
                {
                    b.Property<long>("idTestUser")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<DateTime>("JoinDate");

                    b.Property<int>("JoinType");

                    b.Property<double>("Money");

                    b.Property<string>("Password");

                    b.HasKey("idTestUser");

                    b.ToTable("TestUser");

                    b.HasData(
                        new
                        {
                            idTestUser = 1L,
                            Email = "test01@test.com",
                            JoinDate = new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JoinType = 3,
                            Money = 10.1,
                            Password = "1111"
                        },
                        new
                        {
                            idTestUser = 2L,
                            Email = "test02@test.com",
                            JoinDate = new DateTime(2019, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JoinType = 1,
                            Money = 1000.22,
                            Password = "1111"
                        });
                });

            modelBuilder.Entity("EFCoreCodeFirstSample.ModelDB.TestUserInfo", b =>
                {
                    b.Property<long>("idTestUserInfo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Lv");

                    b.Property<string>("NickName")
                        .HasMaxLength(10);

                    b.Property<long?>("idTestUserForeignKey");

                    b.HasKey("idTestUserInfo");

                    b.HasIndex("idTestUserForeignKey");

                    b.ToTable("TestUserInfo");
                });

            modelBuilder.Entity("EFCoreCodeFirstSample.ModelDB.TestUserInfo", b =>
                {
                    b.HasOne("EFCoreCodeFirstSample.ModelDB.TestUser", "idTestUser")
                        .WithMany()
                        .HasForeignKey("idTestUserForeignKey");
                });
#pragma warning restore 612, 618
        }
    }
}
