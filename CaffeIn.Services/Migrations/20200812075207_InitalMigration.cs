using Microsoft.EntityFrameworkCore.Migrations;

namespace CaffeIn.Services.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kopis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaKopi = table.Column<string>(nullable: true),
                    Deskripsi = table.Column<string>(nullable: true),
                    Harga = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kopis", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Kopis",
                columns: new[] { "Id", "Deskripsi", "Harga", "NamaKopi" },
                values: new object[] { 1, "Kopi yang sangat hitam", 12.0, "Kopi Hitam" });

            migrationBuilder.InsertData(
                table: "Kopis",
                columns: new[] { "Id", "Deskripsi", "Harga", "NamaKopi" },
                values: new object[] { 2, "Kopi dan susu", 5000.0, "Kopi susu" });

            migrationBuilder.InsertData(
                table: "Kopis",
                columns: new[] { "Id", "Deskripsi", "Harga", "NamaKopi" },
                values: new object[] { 3, "Kopi yang sangat pahit", 25.0, "Kopi Pahit" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kopis");
        }
    }
}
