using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantTP.Migrations
{
    /// <inheritdoc />
    public partial class Changefloattodouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "quantity",
                table: "availableProducts",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "quantity",
                table: "availableProducts",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
