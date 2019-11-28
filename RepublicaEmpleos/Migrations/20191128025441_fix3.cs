using Microsoft.EntityFrameworkCore.Migrations;

namespace RepublicaEmpleos.Migrations
{
    public partial class fix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Vehicles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Vehicles",
                nullable: true);
        }
    }
}
