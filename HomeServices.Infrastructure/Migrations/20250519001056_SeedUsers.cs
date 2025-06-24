using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeServices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedAt", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "UpdatedAt", "Username", "WorkPositionId" },
                values: new object[] { 1, "Main Office", new DateTime(2025, 5, 19, 0, 10, 55, 227, DateTimeKind.Utc).AddTicks(1170), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kristijan.georg@gmail.com", "System", "Administrator", "admin123", "076221915", "Admin", new DateTime(2025, 5, 19, 0, 10, 55, 227, DateTimeKind.Utc).AddTicks(1397), "admin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
