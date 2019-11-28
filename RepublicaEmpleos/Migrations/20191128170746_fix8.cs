using Microsoft.EntityFrameworkCore.Migrations;

namespace RepublicaEmpleos.Migrations
{
    public partial class fix8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genders_Profiles_ProfileId",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_EducativeTitleId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_MatiralStatusId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_NationalityId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Genders_ProfileId",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Genders");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_EducativeTitleId",
                table: "Profiles",
                column: "EducativeTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_GenderId",
                table: "Profiles",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_MatiralStatusId",
                table: "Profiles",
                column: "MatiralStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_NationalityId",
                table: "Profiles",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Genders_GenderId",
                table: "Profiles",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Genders_GenderId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_EducativeTitleId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_GenderId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_MatiralStatusId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_NationalityId",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Genders",
                nullable: true);

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
    }
}
