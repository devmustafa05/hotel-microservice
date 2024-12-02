﻿// <auto-generated />
using System;
using HotelManager.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HotelManager.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HotelManager.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("UpdatedByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.ToTable("Citys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddByUserId = 1,
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Adana"
                        },
                        new
                        {
                            Id = 2,
                            AddByUserId = 1,
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Adıyaman"
                        },
                        new
                        {
                            Id = 3,
                            AddByUserId = 1,
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Afyonkarahisar"
                        });
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.ContactLocationMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HotelLocationContactId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("HotelLocationContactId");

                    b.HasIndex("LocationId");

                    b.ToTable("ContactLocationMappings");
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddByUserId")
                        .HasColumnType("integer");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("UpdatedByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddByUserId = 1,
                            CityId = 2,
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "AdanaDistrict"
                        });
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("UpdatedByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_Hotel_Name");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddByUserId = 1,
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            Description = "Havuzlu Villalı Suit Her Şey Dahil",
                            IsActive = true,
                            IsDeleted = false,
                            Latitude = 0m,
                            LocationName = "İstanbul Merkez Hacı Osman",
                            Longitude = 0m,
                            Name = "Antalya Suit Otel"
                        },
                        new
                        {
                            Id = 2,
                            AddByUserId = 1,
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            Description = "Havuzlu Villalı Suit Her Şey Dahil",
                            IsActive = true,
                            IsDeleted = false,
                            Latitude = 0m,
                            LocationName = "İstanbul Merkez Hacı Osman",
                            Longitude = 0m,
                            Name = "İstanbul Suit Otel"
                        });
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.HotelContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddByUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp");

                    b.Property<int>("HotelContactType")
                        .HasColumnType("integer");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("UpdatedByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("Content")
                        .HasDatabaseName("IX_Hotel_Contact_Content");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelContacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddByUserId = 1,
                            Content = "905412045792",
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            HotelContactType = 1,
                            HotelId = 1,
                            IsActive = true,
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            AddByUserId = 1,
                            Content = "mustafa_yener05@hotmail.com",
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            HotelContactType = 2,
                            HotelId = 2,
                            IsActive = true,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.HotelLocationContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("UpdatedByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_Hotel_Location_Contact_Name");

                    b.ToTable("HotelLocationContacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddByUserId = 1,
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            HotelId = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Latitude = 35m,
                            Longitude = 45m
                        },
                        new
                        {
                            Id = 2,
                            AddByUserId = 1,
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            HotelId = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Latitude = 36m,
                            Longitude = 48m
                        });
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.HotelOfficial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddByUserId")
                        .HasColumnType("integer");

                    b.Property<string>("CorporateTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("UpdatedByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Hotel_Official_Name");

                    b.ToTable("HotelOfficials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddByUserId = 1,
                            CorporateTitle = "Müdür",
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            HotelId = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Mustafa",
                            SurName = "Yener"
                        },
                        new
                        {
                            Id = 2,
                            AddByUserId = 1,
                            CorporateTitle = "Müdür2",
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            HotelId = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Mustafa2",
                            SurName = "Yener2"
                        });
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddByUserId")
                        .HasColumnType("integer");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp");

                    b.Property<int>("DistrictId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("UpdatedByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("DistrictId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddByUserId = 1,
                            CityId = 1,
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            DistrictId = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Latitude = 3542m,
                            Longitude = 5542m,
                            Name = "LocationName"
                        },
                        new
                        {
                            Id = 2,
                            AddByUserId = 1,
                            CityId = 1,
                            CreatedDate = new DateTime(2024, 12, 2, 7, 16, 0, 0, DateTimeKind.Local),
                            DistrictId = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Latitude = 3542m,
                            Longitude = 5542m,
                            Name = "LocationName2"
                        });
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.ContactLocationMapping", b =>
                {
                    b.HasOne("HotelManager.Domain.Entities.HotelLocationContact", "HotelLocationContact")
                        .WithMany("LocationHotelLocations")
                        .HasForeignKey("HotelLocationContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManager.Domain.Entities.Location", "Location")
                        .WithMany("LocationHotelLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelLocationContact");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.District", b =>
                {
                    b.HasOne("HotelManager.Domain.Entities.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.HotelContact", b =>
                {
                    b.HasOne("HotelManager.Domain.Entities.Hotel", "Hotel")
                        .WithMany("HotelContacts")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.HotelLocationContact", b =>
                {
                    b.HasOne("HotelManager.Domain.Entities.Hotel", "Hotel")
                        .WithMany("HotelLocationContacts")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.HotelOfficial", b =>
                {
                    b.HasOne("HotelManager.Domain.Entities.Hotel", "Hotel")
                        .WithMany("HotelOfficials")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.Location", b =>
                {
                    b.HasOne("HotelManager.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManager.Domain.Entities.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("District");
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("HotelContacts");

                    b.Navigation("HotelLocationContacts");

                    b.Navigation("HotelOfficials");
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.HotelLocationContact", b =>
                {
                    b.Navigation("LocationHotelLocations");
                });

            modelBuilder.Entity("HotelManager.Domain.Entities.Location", b =>
                {
                    b.Navigation("LocationHotelLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
