using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rij62.Migrations
{
    /// <inheritdoc />
    public partial class PriceCentToPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price_cent",
                table: "products");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "products",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "order_items",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "price_cent",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "order_items",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
