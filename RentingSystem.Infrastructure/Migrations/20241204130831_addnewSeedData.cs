using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addnewSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "Comment of the rent",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Comment of the rent");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3c0fa63-2077-451a-a4ee-4e1697dbd8eb", "AQAAAAIAAYagAAAAEKTIGP64IRI8yvZys6qC8cej1Itt5VRATVbeKFEZZO4jrcNZUZB5AaZniB6JLAXUMw==", "0378646a-c488-463e-8029-04c1c75001d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cc156f8-1f64-4a75-b359-6e8f1d0a5981", "AQAAAAIAAYagAAAAEKohOJGX5b6Kz1T5NnZyPFLCOpKXkwEgZIM65x2eEiJZ5Rw6ihjgngyHAjAmU64rvQ==", "a72bb6f6-fe82-4916-b8ab-1c9ea23814b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3d11fe1-5b69-4547-838f-641e17d957be", "AQAAAAIAAYagAAAAEDaQLT1j0EnN4RvOfu9l1OqvAY8+i0KGrgR8/1fP3LfRnp8D1AMifE0S4dC1YZB5Vw==", "cf35bb3c-d32c-4786-9f46-adb5b47166ca" });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "CarId", "IsReturned", "IsReview", "RentDate", "ReturnDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, false, false, new DateTime(2024, 12, 4, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7719), new DateTime(2024, 12, 7, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7757), "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 2, 2, true, true, new DateTime(2024, 11, 29, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7774), new DateTime(2024, 12, 3, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7776), "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, 2, true, true, new DateTime(2024, 11, 29, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7780), new DateTime(2024, 12, 3, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7782), "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CarId", "Comment", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, 2, "Great car, very comfortable and smooth ride.", 5, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 2, 2, "Good car, but could be better.", 4, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Comment of the rent",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Comment of the rent");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfe6b616-2d5f-478e-9364-2e28e9e2d20f", "AQAAAAIAAYagAAAAECfedbYMxRFeFN41N9wOtdDNNmi0/9b4pwTRyxj9ah4Abn0E4kGmLoDi0G4/CBwcAg==", "67e215cb-e020-4439-959c-e4d9dd685e6a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98517a99-9e8b-42eb-9a45-a159b84f4381", "AQAAAAIAAYagAAAAEMWBh/qt7zHsGXnulZZl35oGyPFrwLoJww6NdJ0whHc+96sPwUPyOc08d3nYPc03ng==", "8583977b-8736-418f-bd9b-71604d9b7d25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "696d58b7-6a76-4b91-b98a-45c4f4aa1869", "AQAAAAIAAYagAAAAELmLxRdRx5kCWtV4ux9nImE6Wadt5zz0ao7RvZnh5VILiVOSIixQOFLEunMmeoCp9Q==", "cd8e758f-bf85-44df-8914-f1a1299a3e59" });
        }
    }
}
