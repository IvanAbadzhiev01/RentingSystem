using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userBalanceAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "Balance", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { 0m, "a0c46837-55c0-416b-8653-f1ac07e1c9bf", "AQAAAAIAAYagAAAAEIdoTLuhYaEH0pYSgMkyRz3Vp3LDt/+TJk7iAPB1cVPftKPv7JQLUbxg1iN8HvlBNQ==", "62941354-da3b-4e48-9588-9688f84ffd8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "Balance", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { 0m, "d0cd0592-7c59-44c3-9710-fc6f8efed02f", "AQAAAAIAAYagAAAAECpGV5F/3LVQQ51iWl9aWW0B1jzJ5hUjn7tct8C+cnjt4UddgTmCTrI8Waah0cgSVw==", "04952a6e-5e3a-4ead-82be-d0c83a6ea483" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "Balance", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { 0m, "22d9e6ef-be31-43ee-aa21-723e0a6cc1a2", "AQAAAAIAAYagAAAAEFjoX5kgm+MRyss5aF6t+9YpjmglQ7cSE7JhiP/NZIqvi4Adzv9NKiqXf72WBGSuCQ==", "0f337975-78ff-4e5f-9cf6-fed48f934774" });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 12, 7, 16, 4, 0, 469, DateTimeKind.Local).AddTicks(5639), new DateTime(2024, 12, 10, 16, 4, 0, 469, DateTimeKind.Local).AddTicks(5672) });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CarId", "RentDate", "ReturnDate" },
                values: new object[] { 3, new DateTime(2024, 12, 2, 16, 4, 0, 469, DateTimeKind.Local).AddTicks(5683), new DateTime(2024, 12, 6, 16, 4, 0, 469, DateTimeKind.Local).AddTicks(5685) });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CarId", "RentDate", "ReturnDate" },
                values: new object[] { 3, new DateTime(2024, 11, 27, 16, 4, 0, 469, DateTimeKind.Local).AddTicks(5690), new DateTime(2024, 11, 29, 16, 4, 0, 469, DateTimeKind.Local).AddTicks(5692) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CarId",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");

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

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 12, 4, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7719), new DateTime(2024, 12, 7, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7757) });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CarId", "RentDate", "ReturnDate" },
                values: new object[] { 2, new DateTime(2024, 11, 29, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7774), new DateTime(2024, 12, 3, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7776) });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CarId", "RentDate", "ReturnDate" },
                values: new object[] { 2, new DateTime(2024, 11, 29, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7780), new DateTime(2024, 12, 3, 15, 8, 28, 22, DateTimeKind.Local).AddTicks(7782) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CarId",
                value: 2);
        }
    }
}
