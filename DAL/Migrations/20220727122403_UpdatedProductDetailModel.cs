using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdatedProductDetailModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDetail_ProductDetailId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetail",
                table: "ProductDetail");

            migrationBuilder.RenameTable(
                name: "ProductDetail",
                newName: "ProductDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products",
                column: "ProductDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailId",
                table: "Products",
                column: "ProductDetailId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails");

            migrationBuilder.RenameTable(
                name: "ProductDetails",
                newName: "ProductDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetail",
                table: "ProductDetail",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products",
                column: "ProductDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDetail_ProductDetailId",
                table: "Products",
                column: "ProductDetailId",
                principalTable: "ProductDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
