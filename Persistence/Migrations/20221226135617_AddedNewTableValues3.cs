using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedNewTableValues3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Info",
                table: "Universities",
                newName: "ShortInfo");

            migrationBuilder.AddColumn<string>(
                name: "FullInfo",
                table: "Universities",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullInfo",
                table: "Universities");

            migrationBuilder.RenameColumn(
                name: "ShortInfo",
                table: "Universities",
                newName: "Info");
        }
    }
}
