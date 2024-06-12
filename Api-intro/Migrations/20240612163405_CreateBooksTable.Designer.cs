﻿// <auto-generated />
using System;
using Api_intro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api_intro.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240612163405_CreateBooksTable")]
    partial class CreateBooksTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Api_intro.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 6, 12, 20, 34, 5, 863, DateTimeKind.Local).AddTicks(7630),
                            Name = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 6, 12, 20, 34, 5, 863, DateTimeKind.Local).AddTicks(7640),
                            Name = "The Summer I Turned Pretty"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 6, 12, 20, 34, 5, 863, DateTimeKind.Local).AddTicks(7640),
                            Name = "Romeo and Juliet"
                        });
                });

            modelBuilder.Entity("Api_intro.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 6, 12, 20, 34, 5, 863, DateTimeKind.Local).AddTicks(7580),
                            Name = "UX UI"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 6, 12, 20, 34, 5, 863, DateTimeKind.Local).AddTicks(7580),
                            Name = "Back-End"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 6, 12, 20, 34, 5, 863, DateTimeKind.Local).AddTicks(7590),
                            Name = "Front-End"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}