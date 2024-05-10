using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityManager.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    cityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.cityId);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "cityId", "cityName" },
                values: new object[,]
                {
                    { new Guid("4095e157-f73e-4227-a846-c93036aabc94"), "Finlande" },
                    { new Guid("a0e25ce7-3f87-46c0-9962-b0e4d1db2d22"), "Toulouse" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
