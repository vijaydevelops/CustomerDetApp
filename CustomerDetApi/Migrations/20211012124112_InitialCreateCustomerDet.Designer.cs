﻿// <auto-generated />
using CustomerDetApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerDetApi.Migrations
{
    [DbContext(typeof(CustDbContext))]
    [Migration("20211012124112_InitialCreateCustomerDet")]
    partial class InitialCreateCustomerDet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("CustomerDetApi.Models.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("countryCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("countryName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            countryCode = "IND",
                            countryName = "INDIA"
                        },
                        new
                        {
                            Id = 2L,
                            countryCode = "PAK",
                            countryName = "PAKISTAN"
                        },
                        new
                        {
                            Id = 3L,
                            countryCode = "SL",
                            countryName = "SRI LANKA"
                        },
                        new
                        {
                            Id = 4L,
                            countryCode = "BNG",
                            countryName = "BANGLADESH"
                        },
                        new
                        {
                            Id = 5L,
                            countryCode = "BHT",
                            countryName = "BHUTAN"
                        },
                        new
                        {
                            Id = 6L,
                            countryCode = "CHN",
                            countryName = "CHINA"
                        },
                        new
                        {
                            Id = 7L,
                            countryCode = "NPL",
                            countryName = "NEPAL"
                        },
                        new
                        {
                            Id = 8L,
                            countryCode = "AFG",
                            countryName = "AFGHANISTHAN"
                        },
                        new
                        {
                            Id = 9L,
                            countryCode = "MYN",
                            countryName = "MYANMAR"
                        },
                        new
                        {
                            Id = 10L,
                            countryCode = "THL",
                            countryName = "THAILAND"
                        },
                        new
                        {
                            Id = 11L,
                            countryCode = "CMB",
                            countryName = "CAMBODIA"
                        },
                        new
                        {
                            Id = 12L,
                            countryCode = "VTM",
                            countryName = "VIETNAM"
                        },
                        new
                        {
                            Id = 13L,
                            countryCode = "JPN",
                            countryName = "JAPAN"
                        },
                        new
                        {
                            Id = 14L,
                            countryCode = "SKOR",
                            countryName = "SOUTH KOREA"
                        },
                        new
                        {
                            Id = 15L,
                            countryCode = "USSR",
                            countryName = "RUSSIAN FEDERATION"
                        },
                        new
                        {
                            Id = 16L,
                            countryCode = "UK",
                            countryName = "UNITED KINGDOM"
                        },
                        new
                        {
                            Id = 17L,
                            countryCode = "DSH",
                            countryName = "GERMANY"
                        },
                        new
                        {
                            Id = 18L,
                            countryCode = "FR",
                            countryName = "FRANCE"
                        });
                });

            modelBuilder.Entity("CustomerDetApi.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("country")
                        .HasColumnType("INTEGER");

                    b.Property<string>("custAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("custCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("custContactNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("custEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("custName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            country = 1,
                            custAddress = "69, Jameson street, Nagpur",
                            custCode = "C0101",
                            custContactNo = "+919456789456",
                            custEmail = "jameson@custdemoapi.com",
                            custName = "NAGPUR JAMESON TRADERS"
                        },
                        new
                        {
                            Id = 2L,
                            country = 1,
                            custAddress = "12/75, Bahadur Sastri Nagar, Indranagar, Bangalore",
                            custCode = "C0102",
                            custContactNo = "+919475645456",
                            custEmail = "laji.pan@gmail.com",
                            custName = "LALJI PAN MASALA"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
