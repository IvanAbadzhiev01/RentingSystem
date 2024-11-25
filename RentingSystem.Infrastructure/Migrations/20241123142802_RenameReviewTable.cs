using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameReviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewiews_AspNetUsers_UserId",
                table: "Rewiews");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewiews_Cars_CarId",
                table: "Rewiews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rewiews",
                table: "Rewiews");

            migrationBuilder.RenameTable(
                name: "Rewiews",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Rewiews_UserId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rewiews_CarId",
                table: "Reviews",
                newName: "IX_Reviews_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Cars_CarId",
                table: "Reviews",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Cars_CarId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Rewiews");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Rewiews",
                newName: "IX_Rewiews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_CarId",
                table: "Rewiews",
                newName: "IX_Rewiews_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rewiews",
                table: "Rewiews",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea191401-4478-4198-b823-e65f190364df", "AQAAAAIAAYagAAAAEEN52OYWmD5UIZv96NkyIU/uTSonh/ixGhg8hWDvrf9WBqBLjDpzZCxCBuItS8ElOw==", "49c9b03b-e93e-4fc2-823f-ff2a5a0a8ad4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5db74164-4231-4ddd-af4d-f85576940c33", "AQAAAAIAAYagAAAAEMJHiRJo08wWyiM+3sjIs3viZjF06QETYdmUw5QMMRS7q+MP+oLKw2GV2d1JkmwqvA==", "49c05908-781f-4e2a-a234-2b6ee580c201" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "175bb747-51e2-4564-9586-81afb327f2ba", "AQAAAAIAAYagAAAAEENzyJVpVuYuVRPCAGfyg4FhNQt8jHozNPVi0SVW9GNxNWOEbNGnde8x/pzuH7NOaw==", "a29efc76-6f4b-44de-8e22-7cadfda02582" });

            migrationBuilder.AddForeignKey(
                name: "FK_Rewiews_AspNetUsers_UserId",
                table: "Rewiews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewiews_Cars_CarId",
                table: "Rewiews",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
