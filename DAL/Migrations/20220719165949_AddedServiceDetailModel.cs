using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedServiceDetailModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Services",
                newName: "Description");

            migrationBuilder.AddColumn<bool>(
                name: "ForHome",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ServiceDetailId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ServiceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetail", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceDetail_ServiceDetailId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "ServiceDetail");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceDetailId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ForHome",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceDetailId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Services",
                newName: "Content");
        }
    }
}
