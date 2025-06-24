using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeServices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitOfMeasureToService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasure",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 1,
                column: "UnitOfMeasure",
                value: "per day");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 2,
                column: "UnitOfMeasure",
                value: "visit");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 3,
                column: "UnitOfMeasure",
                value: "visit");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 4,
                column: "UnitOfMeasure",
                value: "m²");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 5,
                columns: new[] { "Price", "UnitOfMeasure" },
                values: new object[] { 50m, "m" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "Description", "Image", "IsAvailable", "Name", "Price", "UnitOfMeasure" },
                values: new object[,]
                {
                    { 6, "High-efficiency cleaning of industrial or commercial floors using automated machines.", "machine-floor.jpg", true, "Machine Floor Cleaning", 100m, "m²" },
                    { 7, "Professional dry cleaning of garments, suits, and delicate fabrics.", "dry-cleaning.jpg", true, "Dry Cleaning", 100m, "m²" },
                    { 8, "Professional cleaning of carpets.", "carpet.jpg", true, "Carpet Cleaning", 100m, "m²" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "Services");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 5,
                column: "Price",
                value: 450m);
        }
    }
}
