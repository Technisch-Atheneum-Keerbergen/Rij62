using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rij62.Migrations
{
    /// <inheritdoc />
    public partial class multiPresets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "menu_preset_id",
                table: "products");

            migrationBuilder.CreateTable(
                name: "menu_preset_links",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    menu_preset_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu_preset_links");

            migrationBuilder.AddColumn<int>(
                name: "menu_preset_id",
                table: "products",
                type: "integer",
                nullable: true);
        }
    }
}
