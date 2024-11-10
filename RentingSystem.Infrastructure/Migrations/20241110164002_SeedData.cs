using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "91623e92-a510-4986-9dd0-09ad92602334", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAIAAYagAAAAECFw8m/fFcDiS5D7mEMh+mnAWpKcSBL2zF2EHPR/f4cXTA4l+4xQDxpjstDY+QqrNQ==", null, false, "c42f8935-4bb3-4364-a287-4704e227b543", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "cb772f70-c497-4b7b-aecb-1f89b9b05f09", "dealer@mail.com", false, false, null, "DEALER@MAIL.COM", "DEALER@MAIL.COM", "AQAAAAIAAYagAAAAEHVZjMi8xkm7GzqYdlMGEI1q/QIqB960HX4ql4Wfop5QzQYOPy/YAdvxeLu1FJkTNA==", null, false, "0fb46585-294c-4402-b0ad-39b56da54067", false, "dealer@mail.com" },
                    { "e43ce836-997d-4927-ac59-74e8c41bbfd3", 0, "a228bc79-0612-4ae9-8abf-c86bfd160e3f", "admin@mail.com", false, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAED7fdVoyrq2iMpo79sCVTYpGjLeIOlBX2ygYfa2Hhry2hpjlaPdbxie42Uv3HjYF6w==", null, false, "fd188db5-597f-436b-a610-4f6ca1a4050c", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sedan" },
                    { 2, "Hatchback" },
                    { 3, "Station-Wagonan" },
                    { 4, "Coupe" },
                    { 5, "Convertible" },
                    { 6, "Jeep" },
                    { 7, "Pickup" }
                });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "DealerId", "Description", "FuelType", "ImageUrl", "IsApproved", "IsDeleted", "Make", "Model", "PricePerDay", "RenterId", "Seat", "Shift", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 3, 1, "\"App Connect Wireless\"\r\n\r\n\"DIGITAL COCKPIT  PRO 10,25 inch\"\r\n\r\n\"Dynamic Light Assist\"\r\n\r\n\"Emergency call\"\r\n\r\n\"Keyless Access\"\r\n\r\n\"Lane Assist\"\r\n\r\n\"Rear view\"\r\n", "Diesel", "https://office.dlrent.bg/storage/resources_type_images/456aa4ea12ecdd64705f6ef97d993f74.webp", true, false, "VW", "Arteon", 100.00m, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 5, "Automatic", "VW Arteon R-line SB 4MOTION", 2022 },
                    { 2, 2, 1, "The Hyundai i10 is a compact city car known for its practicality, efficiency, and maneuverability, making it ideal for urban driving. Despite its small size, the i10 offers a surprisingly spacious interior with seating for up to five passengers and ample headroom and legroom for a car in its class. It comes equipped with modern features, including a touchscreen infotainment system with smartphone connectivity, advanced safety systems, and efficient engine options that prioritize fuel economy. With its easy handling and compact dimensions, the Hyundai i10 is well-suited for navigating crowded city streets and tight parking spaces, making it a popular choice for city dwellers and young drivers alike.", "Gasoline", "https://office.dlrent.bg/storage/resources_type_images/ac39aadf98d02e09e18d87d723f237eb.webp", true, false, "HUYNDAI", "i 10", 80.00m, null, 5, "Automatic", "HUYNDAI i 10", 2024 },
                    { 3, 6, 1, "App Connect\"\r\n\r\n\"DIGITAL COCKPIT  PRO 10,25 inch\"\r\n\r\n\"Emergency call\"\r\n\r\n\"Keyless Access\"\r\n\r\n\"Lane Assist\"\r\n\r\n\"Light Assist\"\r\n\r\n\"Rear view\"", "Diesel", "https://office.dlrent.bg/storage/resources_type_images/1975152798fef78ef132f1744fe82c59.webp", true, false, "VW", "T-Roc", 120.00m, null, 5, "Automatic", "VW T-Roc R-line 4MOTION", 2022 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
