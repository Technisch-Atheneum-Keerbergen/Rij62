using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rij62.Migrations
{
    /// <inheritdoc />
    public partial class dropQuantityOnOrderItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "order_items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "order_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
