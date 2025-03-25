using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class Comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "CaseNotes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseNotes_CreatedByUserId",
                table: "CaseNotes",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseNotes_AspNetUsers_CreatedByUserId",
                table: "CaseNotes",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseNotes_AspNetUsers_CreatedByUserId",
                table: "CaseNotes");

            migrationBuilder.DropIndex(
                name: "IX_CaseNotes_CreatedByUserId",
                table: "CaseNotes");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "CaseNotes");
        }
    }
}
