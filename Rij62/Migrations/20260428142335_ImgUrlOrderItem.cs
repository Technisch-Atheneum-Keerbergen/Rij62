using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rij62.Migrations
{
    /// <inheritdoc />
    public partial class ImgUrlOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img_url",
                table: "order_items",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img_url",
                table: "order_items");
        }
    }
}
