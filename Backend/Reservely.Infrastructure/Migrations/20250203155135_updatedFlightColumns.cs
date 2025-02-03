using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservely.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedFlightColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassPricingId",
                table: "Flights",
                newName: "FlightClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlightClassId",
                table: "Flights",
                newName: "ClassPricingId");
        }
    }
}
