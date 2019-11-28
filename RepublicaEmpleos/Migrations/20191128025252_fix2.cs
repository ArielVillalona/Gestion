using Microsoft.EntityFrameworkCore.Migrations;

namespace RepublicaEmpleos.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEducatibleTitle",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "IdGender",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "IdMatiralstatus",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "IdNationatily",
                table: "Profiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEducatibleTitle",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdGender",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMatiralstatus",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdNationatily",
                table: "Profiles",
                nullable: true);
        }
    }
}
