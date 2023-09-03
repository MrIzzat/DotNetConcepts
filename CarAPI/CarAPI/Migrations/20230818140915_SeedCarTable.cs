using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CreateDate", "EngineSize", "Fuel", "HasTurbo", "Manufacturer", "Model", "Price", "UpdateDate", "Vin" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 18, 17, 9, 15, 336, DateTimeKind.Local).AddTicks(8514), 2000, "Deisel", true, "BMW", "M5", 25000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 123 },
                    { 2, new DateTime(2023, 8, 18, 17, 9, 15, 336, DateTimeKind.Local).AddTicks(8524), 3000, "Petrol", true, "Lamborghini", "Hurcan", 35000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 931 },
                    { 3, new DateTime(2023, 8, 18, 17, 9, 15, 336, DateTimeKind.Local).AddTicks(8526), -1, "electricity", false, "Tesla", "X", 10000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 323 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
