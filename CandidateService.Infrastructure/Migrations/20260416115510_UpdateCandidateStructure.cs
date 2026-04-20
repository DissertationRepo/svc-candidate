using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCandidateStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "candidates",
                newName: "last_name");

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "candidates",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "first_name",
                table: "candidates");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "candidates",
                newName: "full_name");
        }
    }
}
