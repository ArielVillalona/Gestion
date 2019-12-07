using Microsoft.EntityFrameworkCore.Migrations;

namespace RepublicaEmpleos.Migrations
{
    public partial class docadncevivhle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileVehicle");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Emails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ProfileId",
                table: "Vehicles",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Profiles_ProfileId",
                table: "Vehicles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Profiles_ProfileId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ProfileId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Emails",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "ProfileVehicle",
                columns: table => new
                {
                    ProfileID = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileVehicle", x => new { x.ProfileID, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_ProfileVehicle_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileVehicle_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileVehicle_VehicleId",
                table: "ProfileVehicle",
                column: "VehicleId");
        }
    }
}
