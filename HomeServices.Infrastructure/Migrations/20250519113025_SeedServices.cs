using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeServices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "Description", "Image", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Full home or office cleaning service", "cleaning.jpg", true, "General Cleaning", 2500m },
                    { 2, "Fixing leaks, clogged drains, and pipe installations", "plumbing.jpg", true, "Plumbing", 600m },
                    { 3, "Installation and repair of electrical systems", "electrical.jpg", true, "Electrical Repair", 600m },
                    { 4, "Interior and exterior painting services", "painting.jpg", true, "Painting", 60m },
                    { 5, "Assembly of household or office furniture", "furniture.jpg", true, "Furniture Assembly", 450m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 5);
        }
    }
}
