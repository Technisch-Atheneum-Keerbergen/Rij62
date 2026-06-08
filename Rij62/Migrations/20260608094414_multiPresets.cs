using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    menu_preset_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_menu_preset_links", x => x.id);
                    table.ForeignKey(
                        name: "fk_menu_preset_links_menu_presets_menu_preset_id",
                        column: x => x.menu_preset_id,
                        principalTable: "menu_presets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_menu_preset_links_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menu_preset_product",
                columns: table => new
                {
                    menu_presets_id = table.Column<int>(type: "integer", nullable: false),
                    products_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_menu_preset_product", x => new { x.menu_presets_id, x.products_id });
                    table.ForeignKey(
                        name: "fk_menu_preset_product_menu_presets_menu_presets_id",
                        column: x => x.menu_presets_id,
                        principalTable: "menu_presets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_menu_preset_product_products_products_id",
                        column: x => x.products_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_menu_preset_links_menu_preset_id",
                table: "menu_preset_links",
                column: "menu_preset_id");

            migrationBuilder.CreateIndex(
                name: "ix_menu_preset_links_product_id",
                table: "menu_preset_links",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_menu_preset_product_products_id",
                table: "menu_preset_product",
                column: "products_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu_preset_links");

            migrationBuilder.DropTable(
                name: "menu_preset_product");

            migrationBuilder.AddColumn<int>(
                name: "menu_preset_id",
                table: "products",
                type: "integer",
                nullable: true);
        }
    }
}
