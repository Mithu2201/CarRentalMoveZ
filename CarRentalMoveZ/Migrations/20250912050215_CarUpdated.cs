using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalMoveZ.Migrations
{
    /// <inheritdoc />
    public partial class CarUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fuel",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "NextOilChange",
                table: "Cars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TireReplacement",
                table: "Cars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopSpeed",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fuel",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "NextOilChange",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TireReplacement",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TopSpeed",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Cars");
        }
    }
}
