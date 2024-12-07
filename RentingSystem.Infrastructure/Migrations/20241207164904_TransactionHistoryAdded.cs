using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TransactionHistoryAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b39e2ac6-d88e-433a-80b7-708d16c8f826", "AQAAAAIAAYagAAAAEFCKxDyUjJpFH0rBZYNZczw/jFjO8eImOvbXH+CWFHd9BWZqHxWUuhlJrH1EZQv7eg==", "041ee347-eff1-4680-82ae-380a44a3bea7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0da509d9-a5a6-4f51-8379-bbc5296a3d40", "AQAAAAIAAYagAAAAEBD4OroCuyCdsYsot7sNCCAFZHSx0WFIktk4JFIIxI7LfAtjAsX1QrUBnFFSUxYsAg==", "352d49c8-e6e9-4a32-8b00-c3aa875e97ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e00bfab3-0729-4534-8e2b-ae7eaf9c83c2", "AQAAAAIAAYagAAAAECcNbmcwrH4UsA4LiOtsgf46sIEohkUUaMDITM2S+OPoHh574NK3Ezzc7a3BCPLyWw==", "6c16706c-ef1f-4bfd-9ebb-39837c2c0fda" });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 12, 7, 18, 49, 0, 725, DateTimeKind.Local).AddTicks(4873), new DateTime(2024, 12, 10, 18, 49, 0, 725, DateTimeKind.Local).AddTicks(4910) });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 12, 2, 18, 49, 0, 725, DateTimeKind.Local).AddTicks(4921), new DateTime(2024, 12, 6, 18, 49, 0, 725, DateTimeKind.Local).AddTicks(4923) });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 11, 27, 18, 49, 0, 725, DateTimeKind.Local).AddTicks(4927), new DateTime(2024, 11, 29, 18, 49, 0, 725, DateTimeKind.Local).AddTicks(4929) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0c46837-55c0-416b-8653-f1ac07e1c9bf", "AQAAAAIAAYagAAAAEIdoTLuhYaEH0pYSgMkyRz3Vp3LDt/+TJk7iAPB1cVPftKPv7JQLUbxg1iN8HvlBNQ==", "62941354-da3b-4e48-9588-9688f84ffd8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0cd0592-7c59-44c3-9710-fc6f8efed02f", "AQAAAAIAAYagAAAAECpGV5F/3LVQQ51iWl9aWW0B1jzJ5hUjn7tct8C+cnjt4UddgTmCTrI8Waah0cgSVw==", "04952a6e-5e3a-4ead-82be-d0c83a6ea483" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22d9e6ef-be31-43ee-aa21-723e0a6cc1a2", "AQAAAAIAAYagAAAAEFjoX5kgm+MRyss5aF6t+9YpjmglQ7cSE7JhiP/NZIqvi4Adzv9NKiqXf72WBGSuCQ==", "0f337975-78ff-4e5f-9cf6-fed48f934774" });

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
                columns: new[] { "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 12, 2, 16, 4, 0, 469, DateTimeKind.Local).AddTicks(5683), new DateTime(2024, 12, 6, 16, 4, 0, 469, DateTimeKind.Local).AddTicks(5685) });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 11, 27, 16, 4, 0, 469, DateTimeKind.Local).AddTicks(5690), new DateTime(2024, 11, 29, 16, 4, 0, 469, DateTimeKind.Local).AddTicks(5692) });
        }
    }
}
