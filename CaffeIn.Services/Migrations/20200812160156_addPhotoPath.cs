using Microsoft.EntityFrameworkCore.Migrations;

namespace CaffeIn.Services.Migrations
{
    public partial class addPhotoPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kopis",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kopis",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kopis",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "Harga",
                table: "Kopis",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Kopis",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Kopis");

            migrationBuilder.AlterColumn<decimal>(
                name: "Harga",
                table: "Kopis",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Kopis",
                columns: new[] { "Id", "Deskripsi", "Harga", "NamaKopi" },
                values: new object[] { 1, "Kopi yang sangat hitam", 12000m, "Kopi Hitam" });

            migrationBuilder.InsertData(
                table: "Kopis",
                columns: new[] { "Id", "Deskripsi", "Harga", "NamaKopi" },
                values: new object[] { 2, "Kopi dan susu", 5000m, "Kopi susu" });

            migrationBuilder.InsertData(
                table: "Kopis",
                columns: new[] { "Id", "Deskripsi", "Harga", "NamaKopi" },
                values: new object[] { 3, "Kopi yang sangat pahit", 25000m, "Kopi Pahit" });
        }
    }
}
