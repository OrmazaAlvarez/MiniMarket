﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniMarketBackEnd.Persistence;

namespace MiniMarketBackEnd.Migrations
{
    [DbContext(typeof(MiniMarketDbContext))]
    [Migration("20210506023054_CreateDataBase")]
    partial class CreateDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MiniMarketBackEnd.Models.Category", b =>
                {
                    b.Property<short>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = (short)1,
                            Description = "Category SEDAN 1",
                            Name = "SEDAN"
                        },
                        new
                        {
                            CategoryId = (short)2,
                            Description = "Category SUV 2",
                            Name = "SUV"
                        },
                        new
                        {
                            CategoryId = (short)3,
                            Description = "Category ALL TERRAIN 3",
                            Name = "ALL TERRAIN"
                        });
                });

            modelBuilder.Entity("MiniMarketBackEnd.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<short>("CategoryId")
                        .HasColumnType("smallint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Measure")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<short>("SupplierId")
                        .HasColumnType("smallint");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Brand = "RENAULT",
                            CategoryId = (short)1,
                            Description = "Description for KOLEOS",
                            Measure = "L: 4.399mm, W: 1.652, H: 1.390",
                            Model = "KOLEOS",
                            Price = 10916m,
                            SupplierId = (short)1
                        },
                        new
                        {
                            ProductId = 2,
                            Brand = "RENAULT",
                            CategoryId = (short)1,
                            Description = "Description for KOLEOS",
                            Measure = "L: 4.399mm, W: 1.652, H: 1.390",
                            Model = "KOLEOS",
                            Price = 11219m,
                            SupplierId = (short)1
                        },
                        new
                        {
                            ProductId = 3,
                            Brand = "RENAULT",
                            CategoryId = (short)1,
                            Description = "Description for KOLEOS",
                            Measure = "L: 4.399mm, W: 1.652, H: 1.390",
                            Model = "KOLEOS",
                            Price = 10505m,
                            SupplierId = (short)1
                        },
                        new
                        {
                            ProductId = 4,
                            Brand = "RENAULT",
                            CategoryId = (short)1,
                            Description = "Description for KOLEOS",
                            Measure = "L: 4.399mm, W: 1.652, H: 1.390",
                            Model = "KOLEOS",
                            Price = 14520m,
                            SupplierId = (short)1
                        },
                        new
                        {
                            ProductId = 5,
                            Brand = "Ford",
                            CategoryId = (short)2,
                            Description = "Description for FX-150",
                            Measure = "L: 4.518mm, W: 1.799, H: 1.480",
                            Model = "FX-150",
                            Price = 11039m,
                            SupplierId = (short)1
                        },
                        new
                        {
                            ProductId = 6,
                            Brand = "Ford",
                            CategoryId = (short)2,
                            Description = "Description for FX-150",
                            Measure = "L: 4.518mm, W: 1.799, H: 1.480",
                            Model = "FX-150",
                            Price = 10769m,
                            SupplierId = (short)1
                        },
                        new
                        {
                            ProductId = 7,
                            Brand = "Ford",
                            CategoryId = (short)2,
                            Description = "Description for FX-150",
                            Measure = "L: 4.518mm, W: 1.799, H: 1.480",
                            Model = "FX-150",
                            Price = 10813m,
                            SupplierId = (short)1
                        },
                        new
                        {
                            ProductId = 8,
                            Brand = "Ford",
                            CategoryId = (short)2,
                            Description = "Description for FX-150",
                            Measure = "L: 4.518mm, W: 1.799, H: 1.480",
                            Model = "FX-150",
                            Price = 11807m,
                            SupplierId = (short)1
                        },
                        new
                        {
                            ProductId = 9,
                            Brand = "RENAULT",
                            CategoryId = (short)1,
                            Description = "Description for KOLEOS",
                            Measure = "L: 4.399mm, W: 1.652, H: 1.390",
                            Model = "KOLEOS",
                            Price = 14274m,
                            SupplierId = (short)1
                        });
                });

            modelBuilder.Entity("MiniMarketBackEnd.Models.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("StockId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("StockId");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            StockId = 1,
                            Count = 45,
                            ProductId = 1
                        },
                        new
                        {
                            StockId = 2,
                            Count = 42,
                            ProductId = 2
                        },
                        new
                        {
                            StockId = 3,
                            Count = 42,
                            ProductId = 3
                        },
                        new
                        {
                            StockId = 4,
                            Count = 37,
                            ProductId = 4
                        },
                        new
                        {
                            StockId = 5,
                            Count = 22,
                            ProductId = 5
                        },
                        new
                        {
                            StockId = 6,
                            Count = 49,
                            ProductId = 6
                        },
                        new
                        {
                            StockId = 7,
                            Count = 40,
                            ProductId = 7
                        },
                        new
                        {
                            StockId = 8,
                            Count = 24,
                            ProductId = 8
                        },
                        new
                        {
                            StockId = 9,
                            Count = 21,
                            ProductId = 9
                        });
                });

            modelBuilder.Entity("MiniMarketBackEnd.Models.Supplier", b =>
                {
                    b.Property<short>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("MailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierId = (short)1,
                            Address = "El Empalme - Guayas - Ecuador",
                            MailAddress = "lenin.ormaza@gmail.com",
                            Name = "Lenin Ormaza",
                            PhoneNumber = "+593987461352"
                        });
                });

            modelBuilder.Entity("MiniMarketBackEnd.Models.Product", b =>
                {
                    b.HasOne("MiniMarketBackEnd.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniMarketBackEnd.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniMarketBackEnd.Models.Stock", b =>
                {
                    b.HasOne("MiniMarketBackEnd.Models.Product", null)
                        .WithOne("Stock")
                        .HasForeignKey("MiniMarketBackEnd.Models.Stock", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
