﻿// <auto-generated />
using System;
using CampusQuartersAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CampusQuartersAPI.Migrations
{
    [DbContext(typeof(CampusQuartersDataContext))]
    [Migration("20240422075605_UpdateTables")]
    partial class UpdateTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CampusQuartersAPI.Models.Accommodation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AvailabilityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<double>("Deposit")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LandlordId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Photographed")
                        .HasColumnType("datetime2");

                    b.Property<double>("Rent")
                        .HasColumnType("float");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AvailabilityId");

                    b.HasIndex("LandlordId");

                    b.HasIndex("TypeId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.AccommodationBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BookedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsTaken")
                        .HasColumnType("bit");

                    b.Property<bool>("IsViewed")
                        .HasColumnType("bit");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ViewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("StudentId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.AccommodationImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTaken")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUploaded")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhotographerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("PhotographerId");

                    b.ToTable("AccommodationImages");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.AccommodationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccommodationTypes");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.AccommodationVideo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTaken")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUploaded")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PhotographerId")
                        .HasColumnType("int");

                    b.Property<string>("VideoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("PhotographerId");

                    b.ToTable("AccommodationVideos");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("CellNumber")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Availability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateAvailable")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.AvailabilityStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AvailabilityStatuses");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Landlord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("CellNumber")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Landlords");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Photographer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("CellNumber")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Photographers");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("CellNumber")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Accommodation", b =>
                {
                    b.HasOne("CampusQuartersAPI.Models.Availability", "Availability")
                        .WithMany()
                        .HasForeignKey("AvailabilityId");

                    b.HasOne("CampusQuartersAPI.Models.Landlord", "Landlord")
                        .WithMany("Accommodations")
                        .HasForeignKey("LandlordId");

                    b.HasOne("CampusQuartersAPI.Models.AccommodationType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Availability");

                    b.Navigation("Landlord");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.AccommodationBooking", b =>
                {
                    b.HasOne("CampusQuartersAPI.Models.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId");

                    b.HasOne("CampusQuartersAPI.Models.Student", "Student")
                        .WithMany("Bookings")
                        .HasForeignKey("StudentId");

                    b.Navigation("Accommodation");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.AccommodationImage", b =>
                {
                    b.HasOne("CampusQuartersAPI.Models.Accommodation", null)
                        .WithMany("Images")
                        .HasForeignKey("AccommodationId");

                    b.HasOne("CampusQuartersAPI.Models.Photographer", "Photographer")
                        .WithMany()
                        .HasForeignKey("PhotographerId");

                    b.Navigation("Photographer");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.AccommodationVideo", b =>
                {
                    b.HasOne("CampusQuartersAPI.Models.Accommodation", null)
                        .WithMany("Videos")
                        .HasForeignKey("AccommodationId");

                    b.HasOne("CampusQuartersAPI.Models.Photographer", "Photographer")
                        .WithMany()
                        .HasForeignKey("PhotographerId");

                    b.Navigation("Photographer");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Account", b =>
                {
                    b.HasOne("CampusQuartersAPI.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Administrator", b =>
                {
                    b.HasOne("CampusQuartersAPI.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Availability", b =>
                {
                    b.HasOne("CampusQuartersAPI.Models.AvailabilityStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Landlord", b =>
                {
                    b.HasOne("CampusQuartersAPI.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Photographer", b =>
                {
                    b.HasOne("CampusQuartersAPI.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Student", b =>
                {
                    b.HasOne("CampusQuartersAPI.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Accommodation", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Landlord", b =>
                {
                    b.Navigation("Accommodations");
                });

            modelBuilder.Entity("CampusQuartersAPI.Models.Student", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
