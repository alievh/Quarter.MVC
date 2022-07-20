using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdatedServiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceDetail_ServiceDetailId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceDetailId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceDetail",
                table: "ServiceDetail");

            migrationBuilder.RenameTable(
                name: "ServiceDetail",
                newName: "ServiceDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceDetails",
                table: "ServiceDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceDetailId",
                table: "Services",
                column: "ServiceDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceDetails_ServiceDetailId",
                table: "Services",
                column: "ServiceDetailId",
                principalTable: "ServiceDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceDetails_ServiceDetailId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceDetailId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceDetails",
                table: "ServiceDetails");

            migrationBuilder.RenameTable(
                name: "ServiceDetails",
                newName: "ServiceDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceDetail",
                table: "ServiceDetail",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceDetailId",
                table: "Services",
                column: "ServiceDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceDetail_ServiceDetailId",
                table: "Services",
                column: "ServiceDetailId",
                principalTable: "ServiceDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
