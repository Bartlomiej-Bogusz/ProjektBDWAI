using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektBDWAI.Migrations
{
    /// <inheritdoc />
    public partial class FixOpinie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinie_AspNetUsers_FirstNameId",
                table: "Opinie");

            migrationBuilder.DropForeignKey(
                name: "FK_Opinie_AspNetUsers_LastNameId",
                table: "Opinie");

            migrationBuilder.DropIndex(
                name: "IX_Opinie_FirstNameId",
                table: "Opinie");

            migrationBuilder.DropIndex(
                name: "IX_Opinie_LastNameId",
                table: "Opinie");

            migrationBuilder.DropColumn(
                name: "FirstNameId",
                table: "Opinie");

            migrationBuilder.DropColumn(
                name: "LastNameId",
                table: "Opinie");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Opinie",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Opinie_UserId",
                table: "Opinie",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinie_AspNetUsers_UserId",
                table: "Opinie",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinie_AspNetUsers_UserId",
                table: "Opinie");

            migrationBuilder.DropIndex(
                name: "IX_Opinie_UserId",
                table: "Opinie");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Opinie",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "FirstNameId",
                table: "Opinie",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastNameId",
                table: "Opinie",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Opinie_FirstNameId",
                table: "Opinie",
                column: "FirstNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinie_LastNameId",
                table: "Opinie",
                column: "LastNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinie_AspNetUsers_FirstNameId",
                table: "Opinie",
                column: "FirstNameId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinie_AspNetUsers_LastNameId",
                table: "Opinie",
                column: "LastNameId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
