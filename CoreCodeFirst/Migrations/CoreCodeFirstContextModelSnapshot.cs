﻿// <auto-generated />
using System;
using ModelDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreCodeFirst.Migrations
{
    [DbContext(typeof(CoreCodeFirstContext))]
    partial class CoreCodeFirstContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("CoreCodeFirst.ModelDB.TestUser", b =>
                {
                    b.Property<long>("idTestUser")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("CoreCodeFirst.ModelDB.TestUserInfo", b =>
                {
                    b.Property<long>("idTestUserInfo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Lv");

                    b.Property<double>("Money");

                    b.Property<string>("NickName")
                        .HasMaxLength(10);

                    b.Property<long?>("idTestUserForeignKey");

                    b.HasKey("idTestUserInfo");

                    b.HasIndex("idTestUserForeignKey");

                    b.ToTable("TestUserInfo");
                });

            modelBuilder.Entity("CoreCodeFirst.ModelDB.TestUserInfo", b =>
                {
                    b.HasOne("CoreCodeFirst.ModelDB.TestUser", "idTestUser")
                        .WithMany()
                        .HasForeignKey("idTestUserForeignKey");
                });
#pragma warning restore 612, 618
        }
    }
}
