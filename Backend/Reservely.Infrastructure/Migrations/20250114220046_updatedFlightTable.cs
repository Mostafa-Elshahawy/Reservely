using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservely.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedFlightTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Airline",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Airline",
                table: "Flights");
        }
    }
}
