using Microsoft.EntityFrameworkCore.Migrations;

namespace RepublicaEmpleos.Migrations
{
    public partial class fix5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_EducativeTitleId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_MatiralStatusId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_NationalityId",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_EducativeTitleId",
                table: "Profiles",
                column: "EducativeTitleId",
                unique: true,
                filter: "[EducativeTitleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_MatiralStatusId",
                table: "Profiles",
                column: "MatiralStatusId",
                unique: true,
                filter: "[MatiralStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_NationalityId",
                table: "Profiles",
                column: "NationalityId",
                unique: true,
                filter: "[NationalityId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_EducativeTitleId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_MatiralStatusId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_NationalityId",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_EducativeTitleId",
                table: "Profiles",
                column: "EducativeTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_MatiralStatusId",
                table: "Profiles",
                column: "MatiralStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_NationalityId",
                table: "Profiles",
                column: "NationalityId");
        }
    }
}
