using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservely.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAirportAndClassTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arrival",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Departure",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Flights",
                newName: "DepartureLounge");

            migrationBuilder.AddColumn<int>(
                name: "ArrivalAirportId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArrivalGate",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArrivalLounge",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartureAirportId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartureGate",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gates = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightClasses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ArrivalAirportId",
                table: "Flights",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ClassId",
                table: "Flights",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureAirportId",
                table: "Flights",
                column: "DepartureAirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_ArrivalAirportId",
                table: "Flights",
                column: "ArrivalAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights",
                column: "DepartureAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_FlightClasses_ClassId",
                table: "Flights",
                column: "ClassId",
                principalTable: "FlightClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_ArrivalAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_FlightClasses_ClassId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "FlightClasses");

            migrationBuilder.DropIndex(
                name: "IX_Flights_ArrivalAirportId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_ClassId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_DepartureAirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ArrivalAirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ArrivalGate",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ArrivalLounge",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureAirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureGate",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "DepartureLounge",
                table: "Flights",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "Arrival",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Departure",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
