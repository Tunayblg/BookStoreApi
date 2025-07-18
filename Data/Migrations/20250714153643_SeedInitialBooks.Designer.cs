﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250714153643_SeedInitialBooks")]
    partial class SeedInitialBooks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Paulo Coelho",
                            Name = "Simyacı",
                            PageCount = 184,
                            Price = 49.99m
                        },
                        new
                        {
                            Id = 2,
                            Author = "Jane Austen",
                            Name = "Akıl ve Tutku",
                            PageCount = 345,
                            Price = 59.99m
                        },
                        new
                        {
                            Id = 3,
                            Author = "George Orwell",
                            Name = "1984",
                            PageCount = 328,
                            Price = 69.99m
                        },
                        new
                        {
                            Id = 4,
                            Author = "Robert C. Martin",
                            Name = "Clean Code",
                            PageCount = 464,
                            Price = 99.99m
                        },
                        new
                        {
                            Id = 5,
                            Author = "Ali Yılmaz",
                            Name = "C# ile Programlama",
                            PageCount = 512,
                            Price = 79.99m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
