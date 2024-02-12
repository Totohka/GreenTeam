using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTeam.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Cheques",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_UserId",
                table: "Cheques",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheques_Users_UserId",
                table: "Cheques",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheques_Users_UserId",
                table: "Cheques");

            migrationBuilder.DropIndex(
                name: "IX_Cheques_UserId",
                table: "Cheques");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cheques");
        }
    }
}
