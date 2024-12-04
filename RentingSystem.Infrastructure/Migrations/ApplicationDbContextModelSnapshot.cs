﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentingSystem.Infrasturcture.Data;

#nullable disable

namespace RentingSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            ConcurrencyStamp = "b3d11fe1-5b69-4547-838f-641e17d957be",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Application",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN@MAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEDaQLT1j0EnN4RvOfu9l1OqvAY8+i0KGrgR8/1fP3LfRnp8D1AMifE0S4dC1YZB5Vw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cf35bb3c-d32c-4786-9f46-adb5b47166ca",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        },
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8cc156f8-1f64-4a75-b359-6e8f1d0a5981",
                            Email = "dealer@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Application",
                            LastName = "Dealer",
                            LockoutEnabled = false,
                            NormalizedEmail = "DEALER@MAIL.COM",
                            NormalizedUserName = "DEALER@MAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEKohOJGX5b6Kz1T5NnZyPFLCOpKXkwEgZIM65x2eEiJZ5Rw6ihjgngyHAjAmU64rvQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a72bb6f6-fe82-4916-b8ab-1c9ea23814b3",
                            TwoFactorEnabled = false,
                            UserName = "dealer@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d3c0fa63-2077-451a-a4ee-4e1697dbd8eb",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Application",
                            LastName = "Guest",
                            LockoutEnabled = false,
                            NormalizedEmail = "GUEST@MAIL.COM",
                            NormalizedUserName = "GUEST@MAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEKTIGP64IRI8yvZys6qC8cej1Itt5VRATVbeKFEZZO4jrcNZUZB5AaZniB6JLAXUMw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0378646a-c488-463e-8029-04c1c75001d1",
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

                    b.Property<bool>("IsReview")
                        .HasColumnType("bit")
                        .HasComment("Is the car reviewed or not");

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 1,
                            IsReturned = false,
                            IsReview = false,
                            RentDate = new DateTime(2024, 12, 4, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7719),
                            ReturnDate = new DateTime(2024, 12, 7, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7757),
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        },
                        new
                        {
                            Id = 2,
                            CarId = 2,
                            IsReturned = true,
                            IsReview = true,
                            RentDate = new DateTime(2024, 11, 29, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7774),
                            ReturnDate = new DateTime(2024, 12, 3, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7776),
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        },
                        new
                        {
                            Id = 3,
                            CarId = 2,
                            IsReturned = true,
                            IsReview = true,
                            RentDate = new DateTime(2024, 11, 29, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7780),
                            ReturnDate = new DateTime(2024, 12, 3, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7782),
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
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
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 2,
                            Comment = "Great car, very comfortable and smooth ride.",
                            Rating = 5,
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        },
                        new
                        {
                            Id = 2,
                            CarId = 2,
                            Comment = "Good car, but could be better.",
                            Rating = 4,
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
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
