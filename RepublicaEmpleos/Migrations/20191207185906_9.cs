using Microsoft.EntityFrameworkCore.Migrations;

namespace RepublicaEmpleos.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileDocType_DocTypes_DocTypeID",
                table: "ProfileDocType");

            migrationBuilder.DropIndex(
                name: "IX_ProfileDocType_DocTypeID",
                table: "ProfileDocType");

            migrationBuilder.AddColumn<int>(
                name: "ProfileDocTypeDocTypeID",
                table: "DocTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileDocTypeProfileID",
                table: "DocTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "DocTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "docTypeID",
                table: "DocTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocTypes_ProfileId",
                table: "DocTypes",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_DocTypes_docTypeID",
                table: "DocTypes",
                column: "docTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DocTypes_ProfileDocTypeProfileID_ProfileDocTypeDocTypeID",
                table: "DocTypes",
                columns: new[] { "ProfileDocTypeProfileID", "ProfileDocTypeDocTypeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_DocTypes_Profiles_ProfileId",
                table: "DocTypes",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocTypes_DocTypes_docTypeID",
                table: "DocTypes",
                column: "docTypeID",
                principalTable: "DocTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocTypes_ProfileDocType_ProfileDocTypeProfileID_ProfileDocTypeDocTypeID",
                table: "DocTypes",
                columns: new[] { "ProfileDocTypeProfileID", "ProfileDocTypeDocTypeID" },
                principalTable: "ProfileDocType",
                principalColumns: new[] { "ProfileID", "DocTypeID" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocTypes_Profiles_ProfileId",
                table: "DocTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_DocTypes_DocTypes_docTypeID",
                table: "DocTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_DocTypes_ProfileDocType_ProfileDocTypeProfileID_ProfileDocTypeDocTypeID",
                table: "DocTypes");

            migrationBuilder.DropIndex(
                name: "IX_DocTypes_ProfileId",
                table: "DocTypes");

            migrationBuilder.DropIndex(
                name: "IX_DocTypes_docTypeID",
                table: "DocTypes");

            migrationBuilder.DropIndex(
                name: "IX_DocTypes_ProfileDocTypeProfileID_ProfileDocTypeDocTypeID",
                table: "DocTypes");

            migrationBuilder.DropColumn(
                name: "ProfileDocTypeDocTypeID",
                table: "DocTypes");

            migrationBuilder.DropColumn(
                name: "ProfileDocTypeProfileID",
                table: "DocTypes");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "DocTypes");

            migrationBuilder.DropColumn(
                name: "docTypeID",
                table: "DocTypes");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileDocType_DocTypeID",
                table: "ProfileDocType",
                column: "DocTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileDocType_DocTypes_DocTypeID",
                table: "ProfileDocType",
                column: "DocTypeID",
                principalTable: "DocTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
