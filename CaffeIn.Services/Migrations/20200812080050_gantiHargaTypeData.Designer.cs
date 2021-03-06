﻿// <auto-generated />
using CaffeIn.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaffeIn.Services.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200812080050_gantiHargaTypeData")]
    partial class gantiHargaTypeData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CaffeIn.Models.Kopi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Deskripsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Harga")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NamaKopi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kopis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deskripsi = "Kopi yang sangat hitam",
                            Harga = 12000m,
                            NamaKopi = "Kopi Hitam"
                        },
                        new
                        {
                            Id = 2,
                            Deskripsi = "Kopi dan susu",
                            Harga = 5000m,
                            NamaKopi = "Kopi susu"
                        },
                        new
                        {
                            Id = 3,
                            Deskripsi = "Kopi yang sangat pahit",
                            Harga = 25000m,
                            NamaKopi = "Kopi Pahit"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
