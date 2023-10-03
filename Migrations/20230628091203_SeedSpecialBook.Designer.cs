﻿// <auto-generated />
using AspNetCoreWebApiTask1.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspNetCoreWebApiTask1.Migrations
{
    [DbContext(typeof(BookstoreContext))]
    [Migration("20230628091203_SeedSpecialBook")]
    partial class SeedSpecialBook
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("AspNetCoreWebApiTask1.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookstoreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookstoreId");

                    b.ToTable("Book");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Book");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookstoreId = 1,
                            Name = "Book1"
                        },
                        new
                        {
                            Id = 2,
                            BookstoreId = 1,
                            Name = "Book2"
                        },
                        new
                        {
                            Id = 3,
                            BookstoreId = 2,
                            Name = "Book3"
                        },
                        new
                        {
                            Id = 4,
                            BookstoreId = 3,
                            Name = "Book4"
                        },
                        new
                        {
                            Id = 5,
                            BookstoreId = 3,
                            Name = "Book5"
                        },
                        new
                        {
                            Id = 6,
                            BookstoreId = 3,
                            Name = "Book6"
                        });
                });

            modelBuilder.Entity("AspNetCoreWebApiTask1.Entities.Bookstore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bookstore");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Library1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Library2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Library3"
                        });
                });

            modelBuilder.Entity("AspNetCoreWebApiTask1.Entities.SpecialBook", b =>
                {
                    b.HasBaseType("AspNetCoreWebApiTask1.Entities.Book");

                    b.Property<string>("SpecialEditionDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("SpecialBook");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            BookstoreId = 1,
                            Name = "Book8",
                            SpecialEditionDetails = "SpecialEdition 1"
                        },
                        new
                        {
                            Id = 9,
                            BookstoreId = 2,
                            Name = "Book9",
                            SpecialEditionDetails = "SpecialEdition 2"
                        },
                        new
                        {
                            Id = 10,
                            BookstoreId = 3,
                            Name = "Book10",
                            SpecialEditionDetails = "SpecialEdition 3"
                        },
                        new
                        {
                            Id = 11,
                            BookstoreId = 3,
                            Name = "Book11",
                            SpecialEditionDetails = "SpecialEdition 4"
                        });
                });

            modelBuilder.Entity("AspNetCoreWebApiTask1.Entities.Book", b =>
                {
                    b.HasOne("AspNetCoreWebApiTask1.Entities.Bookstore", "Bookstore")
                        .WithMany("Books")
                        .HasForeignKey("BookstoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bookstore");
                });

            modelBuilder.Entity("AspNetCoreWebApiTask1.Entities.Bookstore", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}