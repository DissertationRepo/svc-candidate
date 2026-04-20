using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidate_skills",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    candidate_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    level = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    years_of_experience = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidate_skills", x => x.id);
                    table.ForeignKey(
                        name: "FK_candidate_skills_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidate_skills_candidate_id",
                table: "candidate_skills",
                column: "candidate_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidate_skills");
        }
    }
}
