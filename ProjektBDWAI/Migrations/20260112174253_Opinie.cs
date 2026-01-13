using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektBDWAI.Migrations
{
    /// <inheritdoc />
    public partial class Opinie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opinie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstNameId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastNameId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opinie_AspNetUsers_FirstNameId",
                        column: x => x.FirstNameId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opinie_AspNetUsers_LastNameId",
                        column: x => x.LastNameId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opinie_FirstNameId",
                table: "Opinie",
                column: "FirstNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinie_LastNameId",
                table: "Opinie",
                column: "LastNameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opinie");
        }
    }
}
