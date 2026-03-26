using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rij62.Migrations
{
    /// <inheritdoc />
    public partial class productSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order_item_choices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    step_number = table.Column<int>(type: "integer", nullable: false),
                    order_item_id = table.Column<int>(type: "integer", nullable: false),
                    chosen_product_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_item_choices", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_item_choices_order_items_order_item_id",
                        column: x => x.order_item_id,
                        principalTable: "order_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_steps",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    default_option_id = table.Column<int>(type: "integer", nullable: true),
                    multiple_choice = table.Column<bool>(type: "boolean", nullable: false),
                    title_key = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_steps", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_steps_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_step_options",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_step_id = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_step_options", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_step_options_product_steps_product_step_id",
                        column: x => x.product_step_id,
                        principalTable: "product_steps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_step_options_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_item_choices_order_item_id",
                table: "order_item_choices",
                column: "order_item_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_step_options_product_id",
                table: "product_step_options",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_step_options_product_step_id",
                table: "product_step_options",
                column: "product_step_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_steps_product_id",
                table: "product_steps",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_item_choices");

            migrationBuilder.DropTable(
                name: "product_step_options");

            migrationBuilder.DropTable(
                name: "product_steps");
        }
    }
}
