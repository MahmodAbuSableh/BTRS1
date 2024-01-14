﻿// <auto-generated />
using System;
using BTRS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTRS.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    partial class SystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BTRS.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("BTRS.Models.Buss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CapName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatsNumber")
                        .HasColumnType("int");

                    b.Property<int>("adminId")
                        .HasColumnType("int");

                    b.Property<int>("tripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("adminId");

                    b.HasIndex("tripId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("BTRS.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("BTRS.Models.Passengers_Trips", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FK_Passnegers")
                        .HasColumnType("int");

                    b.Property<int>("FK_Trips")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_Passnegers");

                    b.HasIndex("FK_Trips");

                    b.ToTable("passenger_trip");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BussNumber")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("adminId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("adminId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("BTRS.Models.Buss", b =>
                {
                    b.HasOne("BTRS.Models.Admin", "Admin")
                        .WithMany("bus")
                        .HasForeignKey("adminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTRS.Models.Trip", "Trip")
                        .WithMany("bus")
                        .HasForeignKey("tripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("BTRS.Models.Passengers_Trips", b =>
                {
                    b.HasOne("BTRS.Models.Passenger", "passenger")
                        .WithMany("passenger_trip")
                        .HasForeignKey("FK_Passnegers")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTRS.Models.Trip", "trip")
                        .WithMany("passenger_trip")
                        .HasForeignKey("FK_Trips")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("passenger");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.HasOne("BTRS.Models.Admin", "Admin")
                        .WithMany("trip")
                        .HasForeignKey("adminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("BTRS.Models.Admin", b =>
                {
                    b.Navigation("bus");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BTRS.Models.Passenger", b =>
                {
                    b.Navigation("passenger_trip");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.Navigation("bus");

                    b.Navigation("passenger_trip");
                });
#pragma warning restore 612, 618
        }
    }
}
