﻿// <auto-generated />
using System;
using AppGroup.Rental.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace AppGroup.Rental.Infrastructure.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.MotodriverEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Cnh")
                        .HasColumnType("text");

                    b.Property<string>("CnhImage")
                        .HasColumnType("text");

                    b.Property<int>("CnhType")
                        .HasColumnType("integer");

                    b.Property<string>("Cnpj")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Cnh")
                        .IsUnique();

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.ToTable("tb_motodrivers", (string)null);
                });

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.MotorcycleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("PlateNumber")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlateNumber")
                        .IsUnique();

                    b.ToTable("tb_motorcycles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("40bc36d8-e64d-43cb-8db4-1ee2921370d6"),
                            CreatedAt = new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7695),
                            Model = "Honda CB 300 R",
                            PlateNumber = "ABC0001",
                            Status = 0,
                            Year = 2015
                        },
                        new
                        {
                            Id = new Guid("e16af1cc-a93e-44a2-9218-b169793c692d"),
                            CreatedAt = new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7711),
                            Model = "Honda CB 300 F",
                            PlateNumber = "ABC0002",
                            Status = 0,
                            Year = 2017
                        },
                        new
                        {
                            Id = new Guid("2ed74138-9577-4531-a976-79770081369a"),
                            CreatedAt = new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7720),
                            Model = "Honda Twister 250",
                            PlateNumber = "ABC0003",
                            Status = 0,
                            Year = 2018
                        },
                        new
                        {
                            Id = new Guid("03d4234d-49fc-4231-9998-f9fcec57bc95"),
                            CreatedAt = new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7729),
                            Model = "Honda Twister 250",
                            PlateNumber = "ABC0004",
                            Status = 0,
                            Year = 2019
                        },
                        new
                        {
                            Id = new Guid("ad8aa3fe-03f4-45bd-946a-20fe64d4ad7a"),
                            CreatedAt = new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7739),
                            Model = "Honda Titan 160",
                            PlateNumber = "ABC0005",
                            Status = 0,
                            Year = 2016
                        },
                        new
                        {
                            Id = new Guid("1b2c7c2b-ec6e-4422-9539-b6da50586d31"),
                            CreatedAt = new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7765),
                            Model = "Honda Titan 160",
                            PlateNumber = "ABC0006",
                            Status = 0,
                            Year = 2017
                        },
                        new
                        {
                            Id = new Guid("08235c98-63f7-4168-9aaf-b1189ac9f11c"),
                            CreatedAt = new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7775),
                            Model = "Yamaha Fazer 250",
                            PlateNumber = "ABC0007",
                            Status = 0,
                            Year = 2016
                        },
                        new
                        {
                            Id = new Guid("5aafa0de-b564-4874-bd64-98ea8269f7fb"),
                            CreatedAt = new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7784),
                            Model = "Yamaha Fazer 250",
                            PlateNumber = "ABC0008",
                            Status = 0,
                            Year = 2020
                        });
                });

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.NotificationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("MotodriverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MotodriverId");

                    b.HasIndex("OrderId");

                    b.ToTable("tb_notifications", (string)null);
                });

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid?>("MotodriverId")
                        .HasColumnType("uuid");

                    b.Property<double>("RaceValue")
                        .HasColumnType("double precision");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MotodriverId");

                    b.ToTable("tb_orders", (string)null);
                });

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.PriceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<double>("Daily")
                        .HasColumnType("double precision");

                    b.Property<int>("Days")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tb_prices", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c29ff565-557d-4eee-b93d-dfec01e31afc"),
                            CreatedAt = new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7633),
                            Daily = 30.0,
                            Days = 7
                        },
                        new
                        {
                            Id = new Guid("1d8d6248-ec0c-41e7-9738-798c06654610"),
                            CreatedAt = new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7677),
                            Daily = 28.0,
                            Days = 15
                        },
                        new
                        {
                            Id = new Guid("ddd5ab8b-3b6e-43fa-b3a4-f761918d004b"),
                            CreatedAt = new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7686),
                            Daily = 22.0,
                            Days = 30
                        });
                });

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.RentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Forecast")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("MotodriverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MotorcycleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PriceId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("double precision");

                    b.Property<double?>("ValueForecast")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("MotodriverId");

                    b.HasIndex("MotorcycleId");

                    b.HasIndex("PriceId");

                    b.ToTable("tb_rents", (string)null);
                });

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.NotificationEntity", b =>
                {
                    b.HasOne("AppGroup.Rental.Domain.Entities.MotodriverEntity", "Motodriver")
                        .WithMany("Notifications")
                        .HasForeignKey("MotodriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Motodrivers_Notifications");

                    b.HasOne("AppGroup.Rental.Domain.Entities.OrderEntity", "Order")
                        .WithMany("Notifications")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Orders_Notifications");

                    b.Navigation("Motodriver");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.OrderEntity", b =>
                {
                    b.HasOne("AppGroup.Rental.Domain.Entities.MotodriverEntity", "Motodriver")
                        .WithMany("Orders")
                        .HasForeignKey("MotodriverId")
                        .HasConstraintName("FK_Orders_Motodrivers");

                    b.Navigation("Motodriver");
                });

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.RentEntity", b =>
                {
                    b.HasOne("AppGroup.Rental.Domain.Entities.MotodriverEntity", "Motodriver")
                        .WithMany("Locations")
                        .HasForeignKey("MotodriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Locations_Motodrivers");

                    b.HasOne("AppGroup.Rental.Domain.Entities.MotorcycleEntity", "Motorcycle")
                        .WithMany("Locations")
                        .HasForeignKey("MotorcycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Locations_Motorcycles");

                    b.HasOne("AppGroup.Rental.Domain.Entities.PriceEntity", "Price")
                        .WithMany("Locations")
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Locations_Prices");

                    b.Navigation("Motodriver");

                    b.Navigation("Motorcycle");

                    b.Navigation("Price");
                });

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.MotodriverEntity", b =>
                {
                    b.Navigation("Locations");

                    b.Navigation("Notifications");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.MotorcycleEntity", b =>
                {
                    b.Navigation("Locations");

                    b.Navigation("Notifications");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.OrderEntity", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("AppGroup.Rental.Domain.Entities.PriceEntity", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
