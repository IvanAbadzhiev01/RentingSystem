using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsReturnedForRents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers");

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "Rents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the car return or not");

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

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: false);

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "Rents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b43f686-c0ff-428d-b9d1-647bb738c40f", "AQAAAAIAAYagAAAAEASSfWVACnWh6bMhy0UFK1aw0IjfAW1Ly8z+8IdoX7QOC+5EnDKheJ7iMVr1ykMPOQ==", "66cad61c-4138-4133-a256-be287d548e11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ed57c82-cdc9-4dfa-a56e-909f184d82c3", "AQAAAAIAAYagAAAAEAONknmBapAu/rr7yt/OlqFV+F4o4O2B+bU//70JQpm2q1DxllgtQfrw9x9yMxGu7Q==", "f265127c-91f7-457c-9768-873c62514ecd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60b1858d-a37f-4900-885f-9152a8808d81", "AQAAAAIAAYagAAAAELJNStPjypFrOzOHOQ+LAdJc6fO6FrMqQmYNjYR+pbvcrJ/oWCpLrkVORw8osYmf6Q==", "38d737cd-4f32-462a-8756-fa1c0486b049" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers",
                column: "UserId");
        }
    }
}
