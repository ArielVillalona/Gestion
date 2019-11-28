using Microsoft.EntityFrameworkCore.Migrations;

namespace RepublicaEmpleos.Migrations
{
    public partial class fix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_GenderId",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_GenderId",
                table: "Profiles",
                column: "GenderId",
                unique: true,
                filter: "[GenderId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_GenderId",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_GenderId",
                table: "Profiles",
                column: "GenderId");
        }
    }
}
