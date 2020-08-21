using Microsoft.EntityFrameworkCore.Migrations;

namespace CaffeIn.Services.Migrations
{
    public partial class removeOrderTotalKolom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "ShoopingCartItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "Harga",
                table: "Kopis",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrderTotal",
                table: "ShoopingCartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Harga",
                table: "Kopis",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal));
        }
    }
}
