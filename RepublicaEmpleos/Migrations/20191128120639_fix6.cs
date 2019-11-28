using Microsoft.EntityFrameworkCore.Migrations;

namespace RepublicaEmpleos.Migrations
{
    public partial class fix6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_ApplicationUserId",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ApplicationUserId",
                table: "Profiles",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_ApplicationUserId",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ApplicationUserId",
                table: "Profiles",
                column: "ApplicationUserId");
        }
    }
}
