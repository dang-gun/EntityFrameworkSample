﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelsDB;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ListField.Migrations.Postgresql
{
    [DbContext(typeof(ModelsDbContext_Postgresql))]
    partial class ModelsDbContext_PostgresqlModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ListField.TableModels.EfList_Test2", b =>
                {
                    b.Property<int>("idEfList_Test2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idEfList_Test2"));

                    b.Property<string>("ListJson1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ListString1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ListString2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("idEfList_Test2");

                    b.ToTable("EfList_Test2");

                    b.HasData(
                        new
                        {
                            idEfList_Test2 = 1,
                            ListJson1 = "[{\"id\":1,\"Name\":\"test1\",\"Age\":11}]",
                            ListString1 = "a11,b11,c11",
                            ListString2 = "a12,b12,c12"
                        },
                        new
                        {
                            idEfList_Test2 = 2,
                            ListJson1 = "[{\"id\":1,\"Name\":\"test2\",\"Age\":12}]",
                            ListString1 = "a21,b21,c21",
                            ListString2 = "a22,b22,c22"
                        },
                        new
                        {
                            idEfList_Test2 = 3,
                            ListJson1 = "[{\"id\":3,\"Name\":\"test3\",\"Age\":13}]",
                            ListString1 = "a31,b31,c31",
                            ListString2 = "a32,b32,c32"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
