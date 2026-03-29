using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rij62.Migrations
{
    /// <inheritdoc />
    public partial class rootCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "screen_id",
                table: "product_categories");

            migrationBuilder.AddColumn<int>(
                name: "root_category",
                table: "product_categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "root_category",
                table: "product_categories");

            migrationBuilder.AddColumn<int>(
                name: "screen_id",
                table: "product_categories",
                type: "integer",
                nullable: true);
        }
    }
}
