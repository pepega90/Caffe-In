using Microsoft.EntityFrameworkCore.Migrations;

namespace CaffeIn.Services.Migrations
{
    public partial class gantiHargaTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Harga",
                table: "Kopis",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Kopis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Harga",
                value: 12000m);

            migrationBuilder.UpdateData(
                table: "Kopis",
                keyColumn: "Id",
                keyValue: 2,
                column: "Harga",
                value: 5000m);

            migrationBuilder.UpdateData(
                table: "Kopis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Harga",
                value: 25000m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Harga",
                table: "Kopis",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.UpdateData(
                table: "Kopis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Harga",
                value: 12.0);

            migrationBuilder.UpdateData(
                table: "Kopis",
                keyColumn: "Id",
                keyValue: 2,
                column: "Harga",
                value: 5000.0);

            migrationBuilder.UpdateData(
                table: "Kopis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Harga",
                value: 25.0);
        }
    }
}
