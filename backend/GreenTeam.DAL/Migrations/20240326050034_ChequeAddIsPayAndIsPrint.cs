using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTeam.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChequeAddIsPayAndIsPrint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPay",
                table: "Cheques",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrint",
                table: "Cheques",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPay",
                table: "Cheques");

            migrationBuilder.DropColumn(
                name: "IsPrint",
                table: "Cheques");
        }
    }
}
