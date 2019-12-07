using Microsoft.EntityFrameworkCore.Migrations;

namespace RepublicaEmpleos.Migrations
{
    public partial class phone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileEmail");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Emails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ProfileId",
                table: "Emails",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Profiles_ProfileId",
                table: "Emails",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Profiles_ProfileId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_ProfileId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Emails");

            migrationBuilder.CreateTable(
                name: "ProfileEmail",
                columns: table => new
                {
                    ProfileID = table.Column<int>(nullable: false),
                    EmailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileEmail", x => new { x.ProfileID, x.EmailID });
                    table.ForeignKey(
                        name: "FK_ProfileEmail_Emails_EmailID",
                        column: x => x.EmailID,
                        principalTable: "Emails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileEmail_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEmail_EmailID",
                table: "ProfileEmail",
                column: "EmailID");
        }
    }
}
