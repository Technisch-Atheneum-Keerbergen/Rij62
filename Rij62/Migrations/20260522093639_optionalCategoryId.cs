using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rij62.Migrations
{
    /// <inheritdoc />
    public partial class optionalCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_products_product_categories_category_id",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_products_product_categories_category_id",
                table: "products",
                column: "category_id",
                principalTable: "product_categories",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_products_product_categories_category_id",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_products_product_categories_category_id",
                table: "products",
                column: "category_id",
                principalTable: "product_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
