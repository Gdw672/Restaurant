using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantTP.Migrations
{
    /// <inheritdoc />
    public partial class RevertMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestForKotya",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestForKotya",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
