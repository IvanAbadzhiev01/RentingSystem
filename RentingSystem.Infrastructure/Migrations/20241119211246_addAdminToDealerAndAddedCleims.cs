using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAdminToDealerAndAddedCleims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Application Admin", "e43ce836-997d-4927-ac59-74e8c41bbfd3" },
                    { 2, "user:fullname", "Application Dealer", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 3, "user:fullname", "Application Guest", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" }
                });

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

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 2, "0000000000000", "e43ce836-997d-4927-ac59-74e8c41bbfd3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e77a829-b557-4743-b65c-58c839b18a79", "AQAAAAIAAYagAAAAECC0WvgCz5D2oV0aF8Aoy30lnPssfUNgyfrGLbPnaYrGanUhqU9g4iGwfmqA4T5pcw==", "34f5ec1e-2ed6-4c18-aef1-18fb52cc5f23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01cb7d39-242c-49c3-896a-cfbb4067fdfd", "AQAAAAIAAYagAAAAEFRsIFanj9y1LVdhcy2hH0Ap/ANEDiFB8flKhQaEZGjfUSw/l69KAD6FyK2eRywLwg==", "9c89b7e2-8df5-414f-a5a2-fdf1cd69f513" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "884bfe60-e8d9-4ec7-9a45-331b435c428c", "AQAAAAIAAYagAAAAEH0zY994Q7YSa14n1lI5VWYn1GXorZ3vYYggwaGT5ubuCQ3sjqbxwjljTQ45AzCPXQ==", "adedc038-dbad-4c3c-934c-3ed4ad096ba0" });
        }
    }
}
