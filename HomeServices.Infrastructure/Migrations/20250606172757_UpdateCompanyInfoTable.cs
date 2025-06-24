using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeServices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompanyInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tax",
                table: "CompanyInfo",
                newName: "TaxNumber");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CompanyInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CompanyInfo");

            migrationBuilder.RenameColumn(
                name: "TaxNumber",
                table: "CompanyInfo",
                newName: "Tax");
        }
    }
}
