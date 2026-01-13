using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektBDWAI.Migrations
{
    /// <inheritdoc />
    public partial class RezerwacjaDni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dni",
                table: "Rezerwacje",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dni",
                table: "Rezerwacje");
        }
    }
}
