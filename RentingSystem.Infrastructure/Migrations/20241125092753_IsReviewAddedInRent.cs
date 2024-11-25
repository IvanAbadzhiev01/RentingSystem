using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsReviewAddedInRent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReview",
                table: "Rents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the car reviewed or not");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReview",
                table: "Rents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c048679-da6c-4037-af6e-f2a558d389d6", "AQAAAAIAAYagAAAAEH9qcyVTPj5Lfehi6R+fj7G8+nrveomZiKZEKT3TYyZysIXjD9RnExeVBkj4zQe8vw==", "5c5a5d0f-8606-4058-9c2f-5425617a8441" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37324f40-5a7c-43ac-9b58-ee0f88ef247a", "AQAAAAIAAYagAAAAEAPTwFyXaCHB80BOrQVVBCOzCLRTh54yKO9ieR6sx7XwKNbc997WQROxs9e6UCQTLg==", "c82cb821-e00f-4fc7-84fa-3734f6b1fcce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d01c6287-7f9a-4d1f-8123-4878674354ff", "AQAAAAIAAYagAAAAEPCuOWVZ2e7OQZ8jBe9I5Iwl7SQ9tmBltQ8Fcf+RFFj8nexYRrdqv0L/fAl/vKucxg==", "5db5a3c4-cb2c-4b9b-b2ad-56ae9f8931de" });
        }
    }
}
