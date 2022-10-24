using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScooterRental.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentedScooters",
                columns: table => new
                {
                    PKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerMinute = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedScooters", x => x.PKey);
                });

            migrationBuilder.CreateTable(
                name: "Scooters",
                columns: table => new
                {
                    PKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerMinute = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scooters", x => x.PKey);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentedScooters");

            migrationBuilder.DropTable(
                name: "Scooters");
        }
    }
}
