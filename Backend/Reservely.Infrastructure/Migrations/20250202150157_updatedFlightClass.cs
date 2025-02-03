using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservely.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedFlightClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightClassPricing");

            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FlightClasses");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "FlightClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassType",
                table: "FlightClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "FlightClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "FlightClasses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TotalSeats",
                table: "FlightClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FlightClasses_FlightId",
                table: "FlightClasses",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightClasses_Flights_FlightId",
                table: "FlightClasses",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightClasses_Flights_FlightId",
                table: "FlightClasses");

            migrationBuilder.DropIndex(
                name: "IX_FlightClasses_FlightId",
                table: "FlightClasses");

            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "FlightClasses");

            migrationBuilder.DropColumn(
                name: "ClassType",
                table: "FlightClasses");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "FlightClasses");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "FlightClasses");

            migrationBuilder.DropColumn(
                name: "TotalSeats",
                table: "FlightClasses");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FlightClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FlightClassPricing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightClassId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightClassPricing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightClassPricing_FlightClasses_FlightClassId",
                        column: x => x.FlightClassId,
                        principalTable: "FlightClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightClassPricing_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightClassPricing_FlightClassId",
                table: "FlightClassPricing",
                column: "FlightClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightClassPricing_FlightId",
                table: "FlightClassPricing",
                column: "FlightId");
        }
    }
}
