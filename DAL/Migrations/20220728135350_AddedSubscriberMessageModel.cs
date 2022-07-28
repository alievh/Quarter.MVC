using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedSubscriberMessageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriberMessageId",
                table: "Subscribers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubscriberMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberMessages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_SubscriberMessageId",
                table: "Subscribers",
                column: "SubscriberMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_SubscriberMessages_SubscriberMessageId",
                table: "Subscribers",
                column: "SubscriberMessageId",
                principalTable: "SubscriberMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_SubscriberMessages_SubscriberMessageId",
                table: "Subscribers");

            migrationBuilder.DropTable(
                name: "SubscriberMessages");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_SubscriberMessageId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "SubscriberMessageId",
                table: "Subscribers");
        }
    }
}
