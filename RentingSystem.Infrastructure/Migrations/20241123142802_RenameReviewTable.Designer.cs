﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentingSystem.Infrasturcture.Data;

#nullable disable

namespace RentingSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241123142802_RenameReviewTable")]
    partial class RenameReviewTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "user:fullname",
                            ClaimValue = "Application Admin",
                            UserId = "e43ce836-997d-4927-ac59-74e8c41bbfd3"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "user:fullname",
                            ClaimValue = "Application Dealer",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "user:fullname",
                            ClaimValue = "Application Guest",
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d01c6287-7f9a-4d1f-8123-4878674354ff",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Application",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN@MAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPCuOWVZ2e7OQZ8jBe9I5Iwl7SQ9tmBltQ8Fcf+RFFj8nexYRrdqv0L/fAl/vKucxg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5db5a3c4-cb2c-4b9b-b2ad-56ae9f8931de",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        },
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "37324f40-5a7c-43ac-9b58-ee0f88ef247a",
                            Email = "dealer@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Application",
                            LastName = "Dealer",
                            LockoutEnabled = false,
                            NormalizedEmail = "DEALER@MAIL.COM",
                            NormalizedUserName = "DEALER@MAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEAPTwFyXaCHB80BOrQVVBCOzCLRTh54yKO9ieR6sx7XwKNbc997WQROxs9e6UCQTLg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c82cb821-e00f-4fc7-84fa-3734f6b1fcce",
                            TwoFactorEnabled = false,
                            UserName = "dealer@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6c048679-da6c-4037-af6e-f2a558d389d6",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Application",
                            LastName = "Guest",
                            LockoutEnabled = false,
                            NormalizedEmail = "GUEST@MAIL.COM",
                            NormalizedUserName = "GUEST@MAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEH9qcyVTPj5Lfehi6R+fj7G8+nrveomZiKZEKT3TYyZysIXjD9RnExeVBkj4zQe8vw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5c5a5d0f-8606-4058-9c2f-5425617a8441",
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        });
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Car identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Car type");

                    b.Property<int>("DealerId")
                        .HasColumnType("int")
                        .HasComment("Car dealer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Car description");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Car fuel type");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Car image url");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit")
                        .HasComment("Is car approved by admin");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Is car deleted");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Car make");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Car model");

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Car price per day");

                    b.Property<string>("RenterId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User id of the renterer");

                    b.Property<int>("Seat")
                        .HasColumnType("int")
                        .HasComment("Car seat");

                    b.Property<string>("Shift")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Car shift");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Car Title");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasComment("Car year of production");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DealerId");

                    b.HasIndex("RenterId");

                    b.ToTable("Cars", t =>
                        {
                            t.HasComment("Car table");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 3,
                            DealerId = 1,
                            Description = "\"App Connect Wireless\"\r\n\r\n\"DIGITAL COCKPIT  PRO 10,25 inch\"\r\n\r\n\"Dynamic Light Assist\"\r\n\r\n\"Emergency call\"\r\n\r\n\"Keyless Access\"\r\n\r\n\"Lane Assist\"\r\n\r\n\"Rear view\"\r\n",
                            FuelType = "Diesel",
                            ImageUrl = "https://office.dlrent.bg/storage/resources_type_images/456aa4ea12ecdd64705f6ef97d993f74.webp",
                            IsApproved = true,
                            IsDeleted = false,
                            Make = "VW",
                            Model = "Arteon",
                            PricePerDay = 100.00m,
                            RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Seat = 5,
                            Shift = "Automatic",
                            Title = "VW Arteon R-line SB 4MOTION",
                            Year = 2022
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            DealerId = 1,
                            Description = "The VW Up-move is a compact city car known for its practicality, efficiency, and maneuverability, making it ideal for urban driving. Despite its small size, the i10 offers a surprisingly spacious interior with seating for up to five passengers and ample headroom and legroom for a car in its class. It comes equipped with modern features, including a touchscreen infotainment system with smartphone connectivity, advanced safety systems, and efficient engine options that prioritize fuel economy. With its easy handling and compact dimensions, the Hyundai i10 is well-suited for navigating crowded city streets and tight parking spaces, making it a popular choice for city dwellers and young drivers alike.",
                            FuelType = "Gasoline",
                            ImageUrl = "https://office.dlrent.bg/storage/resources_type_images/9b391ae0c00eeea3eb655a9d372d647f.webp",
                            IsApproved = false,
                            IsDeleted = false,
                            Make = "VW",
                            Model = "Up-move",
                            PricePerDay = 80.00m,
                            Seat = 5,
                            Shift = "Manual",
                            Title = "VW  Up-move",
                            Year = 2021
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 6,
                            DealerId = 1,
                            Description = "App Connect\"\r\n\r\n\"DIGITAL COCKPIT  PRO 10,25 inch\"\r\n\r\n\"Emergency call\"\r\n\r\n\"Keyless Access\"\r\n\r\n\"Lane Assist\"\r\n\r\n\"Light Assist\"\r\n\r\n\"Rear view\"",
                            FuelType = "Diesel",
                            ImageUrl = "https://office.dlrent.bg/storage/resources_type_images/1975152798fef78ef132f1744fe82c59.webp",
                            IsApproved = true,
                            IsDeleted = false,
                            Make = "VW",
                            Model = "T-Roc",
                            PricePerDay = 120.00m,
                            Seat = 5,
                            Shift = "Automatic",
                            Title = "VW T-Roc R-line 4MOTION",
                            Year = 2022
                        });
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Category name");

                    b.HasKey("Id");

                    b.ToTable("Categories", t =>
                        {
                            t.HasComment("Category of the car");
                        });

                    b.HasData(
                        new
                        {
                            Id = 6,
                            Name = "Jeep"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Sedan"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Station-Wagonan"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Coupe"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Convertible"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Pickup"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hatchback"
                        });
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Dealer identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Dealer Phone Number");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Dealer User Identifier");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Dealers", t =>
                        {
                            t.HasComment("Dealer of the car");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PhoneNumber = "+359888888888",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        },
                        new
                        {
                            Id = 2,
                            PhoneNumber = "0000000000000",
                            UserId = "e43ce836-997d-4927-ac59-74e8c41bbfd3"
                        });
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Rent identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int")
                        .HasComment("Car which is rented");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit")
                        .HasComment("Is the car return or not");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date of renting");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date of returning");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User who rent the product");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Rents", t =>
                        {
                            t.HasComment("Renting of the product");
                        });
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Review identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int")
                        .HasComment("Car which is rented");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Comment of the rent");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasComment("Rating of the rent");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User who rent the product");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews", t =>
                        {
                            t.HasComment("Review of the rent");
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RentingSystem.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RentingSystem.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentingSystem.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RentingSystem.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.Car", b =>
                {
                    b.HasOne("RentingSystem.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RentingSystem.Infrastructure.Data.Models.Dealer", "Dealer")
                        .WithMany("Cars")
                        .HasForeignKey("DealerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RentingSystem.Infrastructure.Data.Models.ApplicationUser", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId");

                    b.Navigation("Category");

                    b.Navigation("Dealer");

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.Dealer", b =>
                {
                    b.HasOne("RentingSystem.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithOne("Dealer")
                        .HasForeignKey("RentingSystem.Infrastructure.Data.Models.Dealer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.Rent", b =>
                {
                    b.HasOne("RentingSystem.Infrastructure.Data.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentingSystem.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.Review", b =>
                {
                    b.HasOne("RentingSystem.Infrastructure.Data.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentingSystem.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RentingSystem.Infrastructure.Data.Models.Dealer", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
