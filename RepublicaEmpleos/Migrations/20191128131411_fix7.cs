using Microsoft.EntityFrameworkCore.Migrations;

namespace RepublicaEmpleos.Migrations
{
    public partial class fix7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Genders_GenderId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_GenderId",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Genders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genders_ProfileId",
                table: "Genders",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genders_Profiles_ProfileId",
                table: "Genders",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genders_Profiles_ProfileId",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Genders_ProfileId",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Genders");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_GenderId",
                table: "Profiles",
                column: "GenderId",
                unique: true,
                filter: "[GenderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Genders_GenderId",
                table: "Profiles",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
