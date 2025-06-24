using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeServices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCheckInOutToTimeOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
    name: "CheckIn",
    table: "Notes",
    type: "time",
    nullable: false,
    oldClrType: typeof(DateTime),
    oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "CheckOut",
                table: "Notes",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
