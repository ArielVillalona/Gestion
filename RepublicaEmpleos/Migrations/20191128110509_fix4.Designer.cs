﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepublicaEmpleos.Data;

namespace RepublicaEmpleos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191128110509_fix4")]
    partial class fix4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RepublicaEmpleos.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Building");

                    b.Property<int?>("NeighborhoodID");

                    b.Property<string>("Street");

                    b.Property<string>("referenc");

                    b.HasKey("Id");

                    b.HasIndex("NeighborhoodID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("RepublicaEmpleos.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("RepublicaEmpleos.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("RepublicaEmpleos.EducativeTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("EducativeTitles");
                });

            modelBuilder.Entity("RepublicaEmpleos.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("RepublicaEmpleos.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("RepublicaEmpleos.MatiralStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("MatiralStatuses");
                });

            modelBuilder.Entity("RepublicaEmpleos.Models.DocType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("DocTypes");
                });

            modelBuilder.Entity("RepublicaEmpleos.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<string>("JobDescription");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("RepublicaEmpleos.Models.ProfileAddress", b =>
                {
                    b.Property<int>("AddressID");

                    b.Property<int>("ProfileID");

                    b.Property<string>("Description");

                    b.HasKey("AddressID", "ProfileID");

                    b.HasIndex("ProfileID");

                    b.ToTable("ProfileAddress");
                });

            modelBuilder.Entity("RepublicaEmpleos.Models.ProfileDocType", b =>
                {
                    b.Property<int>("ProfileID");

                    b.Property<int>("DocTypeID");

                    b.HasKey("ProfileID", "DocTypeID");

                    b.HasIndex("DocTypeID");

                    b.ToTable("ProfileDocType");
                });

            modelBuilder.Entity("RepublicaEmpleos.Models.ProfileEmail", b =>
                {
                    b.Property<int>("ProfileID");

                    b.Property<int>("EmailID");

                    b.HasKey("ProfileID", "EmailID");

                    b.HasIndex("EmailID");

                    b.ToTable("ProfileEmail");
                });

            modelBuilder.Entity("RepublicaEmpleos.Models.ProfilePhone", b =>
                {
                    b.Property<int>("PhoneId");

                    b.Property<int>("ProfileId");

                    b.HasKey("PhoneId", "ProfileId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfilePhone");
                });

            modelBuilder.Entity("RepublicaEmpleos.Models.ProfileVehicle", b =>
                {
                    b.Property<int>("ProfileID");

                    b.Property<int>("VehicleId");

                    b.HasKey("ProfileID", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ProfileVehicle");
                });

            modelBuilder.Entity("RepublicaEmpleos.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("RepublicaEmpleos.Neighborhood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("SectorID");

                    b.HasKey("Id");

                    b.HasIndex("SectorID");

                    b.ToTable("Neighborhoods");
                });

            modelBuilder.Entity("RepublicaEmpleos.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("RepublicaEmpleos.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int?>("EducativeTitleId");

                    b.Property<int?>("GenderId");

                    b.Property<bool>("HeadHome");

                    b.Property<string>("ImagePath");

                    b.Property<string>("LastName");

                    b.Property<int?>("MatiralStatusId");

                    b.Property<string>("Name");

                    b.Property<int?>("NationalityId");

                    b.Property<string>("Objetiv");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("EducativeTitleId");

                    b.HasIndex("GenderId")
                        .IsUnique()
                        .HasFilter("[GenderId] IS NOT NULL");

                    b.HasIndex("MatiralStatusId");

                    b.HasIndex("NationalityId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("RepublicaEmpleos.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityID");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.HasIndex("CityID");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("RepublicaEmpleos.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Matricula");

                    b.Property<int?>("VehicleTypeId");

                    b.HasKey("Id");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("RepublicaEmpleos.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RepublicaEmpleos.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RepublicaEmpleos.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RepublicaEmpleos.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RepublicaEmpleos.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RepublicaEmpleos.Address", b =>
                {
                    b.HasOne("RepublicaEmpleos.Neighborhood", "Neighborhood")
                        .WithMany("Addresses")
                        .HasForeignKey("NeighborhoodID");
                });

            modelBuilder.Entity("RepublicaEmpleos.City", b =>
                {
                    b.HasOne("RepublicaEmpleos.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("RepublicaEmpleos.Models.ProfileAddress", b =>
                {
                    b.HasOne("RepublicaEmpleos.Address", "Address")
                        .WithMany("ProfileAddresses")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RepublicaEmpleos.Profile", "Profile")
                        .WithMany("ProfileAddresses")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RepublicaEmpleos.Models.ProfileDocType", b =>
                {
                    b.HasOne("RepublicaEmpleos.Models.DocType", "DocType")
                        .WithMany("ProfileDocTypes")
                        .HasForeignKey("DocTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RepublicaEmpleos.Profile", "Profile")
                        .WithMany("ProfileDocTypes")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RepublicaEmpleos.Models.ProfileEmail", b =>
                {
                    b.HasOne("RepublicaEmpleos.Email", "Email")
                        .WithMany("ProfileEmails")
                        .HasForeignKey("EmailID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RepublicaEmpleos.Profile", "Profile")
                        .WithMany("ProfileEmails")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RepublicaEmpleos.Models.ProfilePhone", b =>
                {
                    b.HasOne("RepublicaEmpleos.Phone", "Phone")
                        .WithMany("ProfilePhones")
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RepublicaEmpleos.Profile", "Profile")
                        .WithMany("ProfilePhones")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RepublicaEmpleos.Models.ProfileVehicle", b =>
                {
                    b.HasOne("RepublicaEmpleos.Profile", "Profile")
                        .WithMany("ProfileVehicles")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RepublicaEmpleos.Vehicle", "Vehicle")
                        .WithMany("ProfileVehicles")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RepublicaEmpleos.Neighborhood", b =>
                {
                    b.HasOne("RepublicaEmpleos.Sector", "Sector")
                        .WithMany("Neighborhoods")
                        .HasForeignKey("SectorID");
                });

            modelBuilder.Entity("RepublicaEmpleos.Profile", b =>
                {
                    b.HasOne("RepublicaEmpleos.Models.Identity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("RepublicaEmpleos.EducativeTitle", "EducativeTitle")
                        .WithMany()
                        .HasForeignKey("EducativeTitleId");

                    b.HasOne("RepublicaEmpleos.Gender", "Gender")
                        .WithOne("Profile")
                        .HasForeignKey("RepublicaEmpleos.Profile", "GenderId");

                    b.HasOne("RepublicaEmpleos.MatiralStatus", "MatiralStatus")
                        .WithMany()
                        .HasForeignKey("MatiralStatusId");

                    b.HasOne("RepublicaEmpleos.Nationality", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId");
                });

            modelBuilder.Entity("RepublicaEmpleos.Sector", b =>
                {
                    b.HasOne("RepublicaEmpleos.City", "City")
                        .WithMany("Sectors")
                        .HasForeignKey("CityID");
                });

            modelBuilder.Entity("RepublicaEmpleos.Vehicle", b =>
                {
                    b.HasOne("RepublicaEmpleos.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
