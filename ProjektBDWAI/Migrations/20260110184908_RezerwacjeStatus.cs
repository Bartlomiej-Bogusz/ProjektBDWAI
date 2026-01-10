using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektBDWAI.Migrations
{
    /// <inheritdoc />
    public partial class RezerwacjeStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Platnosci_RezerwacjaId",
                table: "Platnosci");

            migrationBuilder.DropColumn(
                name: "DataDo",
                table: "Rezerwacje");

            migrationBuilder.RenameColumn(
                name: "DataOd",
                table: "Rezerwacje",
                newName: "DataUtworzenia");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Rezerwacje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Platnosci_RezerwacjaId",
                table: "Platnosci",
                column: "RezerwacjaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Platnosci_RezerwacjaId",
                table: "Platnosci");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rezerwacje");

            migrationBuilder.RenameColumn(
                name: "DataUtworzenia",
                table: "Rezerwacje",
                newName: "DataOd");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDo",
                table: "Rezerwacje",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Platnosci_RezerwacjaId",
                table: "Platnosci",
                column: "RezerwacjaId",
                unique: true);
        }
    }
}
