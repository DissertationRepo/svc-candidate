using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DbRestructuring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidate_experiences_candidates_candidate_id",
                table: "candidate_experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_candidate_skills_candidates_candidate_id",
                table: "candidate_skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidates",
                table: "candidates");

            migrationBuilder.DropIndex(
                name: "IX_candidates_user_id",
                table: "candidates");

            migrationBuilder.DropColumn(
                name: "id",
                table: "candidates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidates",
                table: "candidates",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_candidate_experiences_candidates_candidate_id",
                table: "candidate_experiences",
                column: "candidate_id",
                principalTable: "candidates",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_candidate_skills_candidates_candidate_id",
                table: "candidate_skills",
                column: "candidate_id",
                principalTable: "candidates",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidate_experiences_candidates_candidate_id",
                table: "candidate_experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_candidate_skills_candidates_candidate_id",
                table: "candidate_skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidates",
                table: "candidates");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "candidates",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidates",
                table: "candidates",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_candidates_user_id",
                table: "candidates",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_candidate_experiences_candidates_candidate_id",
                table: "candidate_experiences",
                column: "candidate_id",
                principalTable: "candidates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_candidate_skills_candidates_candidate_id",
                table: "candidate_skills",
                column: "candidate_id",
                principalTable: "candidates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
