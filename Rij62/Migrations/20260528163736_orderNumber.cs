using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rij62.Migrations
{
    /// <inheritdoc />
    public partial class orderNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
CREATE TABLE IF NOT EXISTS order_number_state (
    order_date date PRIMARY KEY,
    last_value bigint NOT NULL
);
");

            migrationBuilder.Sql(@"
CREATE OR REPLACE FUNCTION next_order_number()
RETURNS bigint AS $$
DECLARE
    today date := CURRENT_DATE;
    next_val bigint;
BEGIN
    INSERT INTO order_number_state(order_date, last_value)
    VALUES (today, 1)
    ON CONFLICT (order_date)
    DO UPDATE SET last_value = order_number_state.last_value + 1
    RETURNING last_value INTO next_val;

    RETURN next_val;
END;
$$ LANGUAGE plpgsql;
");

            migrationBuilder.AddColumn<int>(
                name: "order_number",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValueSql: "next_order_number()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_number",
                table: "orders");

            migrationBuilder.Sql("DROP FUNCTION IF EXISTS next_order_number();");
            migrationBuilder.Sql("DROP TABLE order_number_state");
        }
    }
}
