using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchesOfKnowledge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchesOfKnowledge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Region = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Website = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchOfKnowledgeSpecialties",
                columns: table => new
                {
                    BranchOfKnowledgeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SpecialtyId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOfKnowledgeSpecialties", x => new { x.BranchOfKnowledgeId, x.SpecialtyId });
                    table.ForeignKey(
                        name: "FK_BranchOfKnowledgeSpecialties_BranchesOfKnowledge_BranchOfKnowledgeId",
                        column: x => x.BranchOfKnowledgeId,
                        principalTable: "BranchesOfKnowledge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchOfKnowledgeSpecialties_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialtyDisciplines",
                columns: table => new
                {
                    SpecialtyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DisciplineId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialtyDisciplines", x => new { x.SpecialtyId, x.DisciplineId });
                    table.ForeignKey(
                        name: "FK_SpecialtyDisciplines_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialtyDisciplines_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniversityBranchesOfKnowledge",
                columns: table => new
                {
                    UniversityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BranchOfKnowledgeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityBranchesOfKnowledge", x => new { x.UniversityId, x.BranchOfKnowledgeId });
                    table.ForeignKey(
                        name: "FK_UniversityBranchesOfKnowledge_BranchesOfKnowledge_BranchOfKnowledgeId",
                        column: x => x.BranchOfKnowledgeId,
                        principalTable: "BranchesOfKnowledge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniversityBranchesOfKnowledge_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchOfKnowledgeSpecialties_SpecialtyId",
                table: "BranchOfKnowledgeSpecialties",
                column: "SpecialtyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialtyDisciplines_DisciplineId",
                table: "SpecialtyDisciplines",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityBranchesOfKnowledge_BranchOfKnowledgeId",
                table: "UniversityBranchesOfKnowledge",
                column: "BranchOfKnowledgeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchOfKnowledgeSpecialties");

            migrationBuilder.DropTable(
                name: "SpecialtyDisciplines");

            migrationBuilder.DropTable(
                name: "UniversityBranchesOfKnowledge");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "BranchesOfKnowledge");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
