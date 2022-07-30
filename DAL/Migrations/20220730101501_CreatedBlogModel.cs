using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CreatedBlogModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoryId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BlogCategoryId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "BlogCategoryId",
                table: "Blogs",
                newName: "BlogDetailId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "BlogCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BlogBlogCategory",
                columns: table => new
                {
                    BlogCategoriesId = table.Column<int>(type: "int", nullable: false),
                    BlogsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogBlogCategory", x => new { x.BlogCategoriesId, x.BlogsId });
                    table.ForeignKey(
                        name: "FK_BlogBlogCategory_BlogCategories_BlogCategoriesId",
                        column: x => x.BlogCategoriesId,
                        principalTable: "BlogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogBlogCategory_Blogs_BlogsId",
                        column: x => x.BlogsId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogDetails",
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
                    table.PrimaryKey("PK_BlogDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogDetailId",
                table: "Blogs",
                column: "BlogDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogBlogCategory_BlogsId",
                table: "BlogBlogCategory",
                column: "BlogsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogDetails_BlogDetailId",
                table: "Blogs",
                column: "BlogDetailId",
                principalTable: "BlogDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogDetails_BlogDetailId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "BlogBlogCategory");

            migrationBuilder.DropTable(
                name: "BlogDetails");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BlogDetailId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "BlogCategories");

            migrationBuilder.RenameColumn(
                name: "BlogDetailId",
                table: "Blogs",
                newName: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogCategoryId",
                table: "Blogs",
                column: "BlogCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoryId",
                table: "Blogs",
                column: "BlogCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
