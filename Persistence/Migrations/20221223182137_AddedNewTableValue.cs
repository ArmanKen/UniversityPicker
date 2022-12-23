using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedNewTableValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Universities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Universities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Specialties",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Specialties",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Disciplines",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Disciplines");
        }
    }
}
