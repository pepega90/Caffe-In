using Microsoft.EntityFrameworkCore.Migrations;

namespace CaffeIn.Services.Migrations
{
    public partial class addUserFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoopingCartItems_AspNetUsers_ApplicationUserId",
                table: "ShoopingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoopingCartItems_ApplicationUserId",
                table: "ShoopingCartItems");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ShoopingCartItems");

            migrationBuilder.AddColumn<decimal>(
                name: "OrderTotal",
                table: "ShoopingCartItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoopingCartItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoopingCartItems_UserId",
                table: "ShoopingCartItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoopingCartItems_AspNetUsers_UserId",
                table: "ShoopingCartItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoopingCartItems_AspNetUsers_UserId",
                table: "ShoopingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoopingCartItems_UserId",
                table: "ShoopingCartItems");

            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "ShoopingCartItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoopingCartItems");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ShoopingCartItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoopingCartItems_ApplicationUserId",
                table: "ShoopingCartItems",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoopingCartItems_AspNetUsers_ApplicationUserId",
                table: "ShoopingCartItems",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
