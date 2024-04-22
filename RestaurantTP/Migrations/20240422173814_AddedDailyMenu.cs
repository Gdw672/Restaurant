using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantTP.Migrations
{
    /// <inheritdoc />
    public partial class AddedDailyMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingridients_dishes_DishId",
                table: "ingridients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dishes",
                table: "dishes");

            migrationBuilder.RenameTable(
                name: "dishes",
                newName: "DBDish");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DBDish",
                table: "DBDish",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ingridients_DBDish_DishId",
                table: "ingridients",
                column: "DishId",
                principalTable: "DBDish",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingridients_DBDish_DishId",
                table: "ingridients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DBDish",
                table: "DBDish");

            migrationBuilder.RenameTable(
                name: "DBDish",
                newName: "dishes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dishes",
                table: "dishes",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ingridients_dishes_DishId",
                table: "ingridients",
                column: "DishId",
                principalTable: "dishes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
