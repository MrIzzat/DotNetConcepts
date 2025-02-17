using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenity", "CreateDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It is the villa for kings and queens", "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/fe/c7/a2/one-bedroom-pool-villa.jpg?w=1200&h=-1&s=1", "Royal Villa", 5, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It is the villa for Bronze Peuple", "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/fe/c7/a2/one-bedroom-pool-villa.jpg?w=1200&h=-1&s=1", "Bronze Villa", 3, 50.0, 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It is the villa for Silver People", "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/fe/c7/a2/one-bedroom-pool-villa.jpg?w=1200&h=-1&s=1", "Silver Villa", 4, 70.0, 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It is the villa for Gold People", "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/fe/c7/a2/one-bedroom-pool-villa.jpg?w=1200&h=-1&s=1", "Gold Villa", 5, 100.0, 350, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It is the villa for Diamond People", "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/fe/c7/a2/one-bedroom-pool-villa.jpg?w=1200&h=-1&s=1", "Diamond Villa", 6, 250.0, 400, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
