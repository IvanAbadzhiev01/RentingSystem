using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MainTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Category of the car");

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Dealer identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Dealer Phone Number"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Dealer User Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dealers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Dealer of the car");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Car identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Car Title"),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Car make"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Car model"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "Car year of production"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Car type"),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Car price per day"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false, comment: "Car description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Car image url"),
                    DealerId = table.Column<int>(type: "int", nullable: false, comment: "Car dealer"),
                    RenterId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "User id of the renterer"),
                    Shift = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Car shift"),
                    Seat = table.Column<int>(type: "int", nullable: false, comment: "Car seat"),
                    FuelType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Car fuel type"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Is car deleted"),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, comment: "Is car approved by admin")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_RenterId",
                        column: x => x.RenterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cars_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id");
                },
                comment: "Car table");

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Rent identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User who rent the product"),
                    CarId = table.Column<int>(type: "int", nullable: false, comment: "Car which is rented"),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of renting"),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of returning")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Renting of the product");

            migrationBuilder.CreateTable(
                name: "Rewiews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Review identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User who rent the product"),
                    CarId = table.Column<int>(type: "int", nullable: false, comment: "Car which is rented"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Rating of the rent"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment of the rent")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewiews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewiews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rewiews_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Review of the rent");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DealerId",
                table: "Cars",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RenterId",
                table: "Cars",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_PhoneNumber",
                table: "Dealers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CarId",
                table: "Rents",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserId",
                table: "Rents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewiews_CarId",
                table: "Rewiews",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewiews_UserId",
                table: "Rewiews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Rewiews");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Dealers");
        }
    }
}
