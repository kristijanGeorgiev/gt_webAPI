using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeServices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNotesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "Notes",
    columns: table => new
    {
        NotesId = table.Column<int>(nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        BookingId = table.Column<int>(nullable: false),
        UserId = table.Column<int>(nullable: false),
        CheckIn = table.Column<DateTime>(nullable: false),
        CheckOut = table.Column<DateTime>(nullable: false),
        NoteText = table.Column<string>(maxLength: 1000, nullable: false),
        // other fields...
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Notes", x => x.NotesId);
        table.ForeignKey(
            name: "FK_Notes_Bookings_BookingId",
            column: x => x.BookingId,
            principalTable: "Bookings",
            principalColumn: "BookingID",
            onDelete: ReferentialAction.Restrict);
        table.ForeignKey(
            name: "FK_Notes_Users_UserId",
            column: x => x.UserId,
            principalTable: "Users",
            principalColumn: "UserId",
            onDelete: ReferentialAction.Restrict);
    });

        }
    }
}
