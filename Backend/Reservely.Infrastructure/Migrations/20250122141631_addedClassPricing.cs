using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservely.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedClassPricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_FlightClasses_ClassId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_ClassId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "FlightClasses");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Flights",
                newName: "ClassPricingId");

            migrationBuilder.CreateTable(
                name: "FlightClassPricing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    FlightClassId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightClassPricing");

            migrationBuilder.RenameColumn(
                name: "ClassPricingId",
                table: "Flights",
                newName: "ClassId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "FlightClasses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ClassId",
                table: "Flights",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_FlightClasses_ClassId",
                table: "Flights",
                column: "ClassId",
                principalTable: "FlightClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
