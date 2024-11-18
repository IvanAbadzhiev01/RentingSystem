using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class extendedIdentityUserToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e77a829-b557-4743-b65c-58c839b18a79", "Application", "Guest", "AQAAAAIAAYagAAAAECC0WvgCz5D2oV0aF8Aoy30lnPssfUNgyfrGLbPnaYrGanUhqU9g4iGwfmqA4T5pcw==", "34f5ec1e-2ed6-4c18-aef1-18fb52cc5f23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01cb7d39-242c-49c3-896a-cfbb4067fdfd", "Application", "Dealer", "AQAAAAIAAYagAAAAEFRsIFanj9y1LVdhcy2hH0Ap/ANEDiFB8flKhQaEZGjfUSw/l69KAD6FyK2eRywLwg==", "9c89b7e2-8df5-414f-a5a2-fdf1cd69f513" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "884bfe60-e8d9-4ec7-9a45-331b435c428c", "Application", "Admin", "AQAAAAIAAYagAAAAEH0zY994Q7YSa14n1lI5VWYn1GXorZ3vYYggwaGT5ubuCQ3sjqbxwjljTQ45AzCPXQ==", "adedc038-dbad-4c3c-934c-3ed4ad096ba0" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Make", "Model", "Shift", "Title", "Year" },
                values: new object[] { "The VW Up-move is a compact city car known for its practicality, efficiency, and maneuverability, making it ideal for urban driving. Despite its small size, the i10 offers a surprisingly spacious interior with seating for up to five passengers and ample headroom and legroom for a car in its class. It comes equipped with modern features, including a touchscreen infotainment system with smartphone connectivity, advanced safety systems, and efficient engine options that prioritize fuel economy. With its easy handling and compact dimensions, the Hyundai i10 is well-suited for navigating crowded city streets and tight parking spaces, making it a popular choice for city dwellers and young drivers alike.", "https://office.dlrent.bg/storage/resources_type_images/9b391ae0c00eeea3eb655a9d372d647f.webp", "VW", "Up-move", "Manual", "VW  Up-move", 2021 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91623e92-a510-4986-9dd0-09ad92602334", "AQAAAAIAAYagAAAAECFw8m/fFcDiS5D7mEMh+mnAWpKcSBL2zF2EHPR/f4cXTA4l+4xQDxpjstDY+QqrNQ==", "c42f8935-4bb3-4364-a287-4704e227b543" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb772f70-c497-4b7b-aecb-1f89b9b05f09", "AQAAAAIAAYagAAAAEHVZjMi8xkm7GzqYdlMGEI1q/QIqB960HX4ql4Wfop5QzQYOPy/YAdvxeLu1FJkTNA==", "0fb46585-294c-4402-b0ad-39b56da54067" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a228bc79-0612-4ae9-8abf-c86bfd160e3f", "AQAAAAIAAYagAAAAED7fdVoyrq2iMpo79sCVTYpGjLeIOlBX2ygYfa2Hhry2hpjlaPdbxie42Uv3HjYF6w==", "fd188db5-597f-436b-a610-4f6ca1a4050c" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Make", "Model", "Shift", "Title", "Year" },
                values: new object[] { "The Hyundai i10 is a compact city car known for its practicality, efficiency, and maneuverability, making it ideal for urban driving. Despite its small size, the i10 offers a surprisingly spacious interior with seating for up to five passengers and ample headroom and legroom for a car in its class. It comes equipped with modern features, including a touchscreen infotainment system with smartphone connectivity, advanced safety systems, and efficient engine options that prioritize fuel economy. With its easy handling and compact dimensions, the Hyundai i10 is well-suited for navigating crowded city streets and tight parking spaces, making it a popular choice for city dwellers and young drivers alike.", "https://office.dlrent.bg/storage/resources_type_images/ac39aadf98d02e09e18d87d723f237eb.webp", "HUYNDAI", "i 10", "Automatic", "HUYNDAI i 10", 2024 });
        }
    }
}
