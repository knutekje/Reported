using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reported.Migrations
{
    /// <inheritdoc />
    public partial class addedfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "VerifiedReports",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "VerifiedReports",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Reports",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "VerifiedReports");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "VerifiedReports");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Reports");
        }
    }
}
