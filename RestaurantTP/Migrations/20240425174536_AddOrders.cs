using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantTP.Migrations
{
    /// <inheritdoc />
    public partial class AddOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingridients_dishes_DishId",
                table: "ingridients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ingridients",
                table: "ingridients");

            migrationBuilder.RenameTable(
                name: "ingridients",
                newName: "ingredients");

            migrationBuilder.RenameIndex(
                name: "IX_ingridients_DishId",
                table: "ingredients",
                newName: "IX_ingredients_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ingredients",
                table: "ingredients",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "orderComponents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderComponents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ingredients_dishes_DishId",
                table: "ingredients",
                column: "DishId",
                principalTable: "dishes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredients_dishes_DishId",
                table: "ingredients");

            migrationBuilder.DropTable(
                name: "orderComponents");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ingredients",
                table: "ingredients");

            migrationBuilder.RenameTable(
                name: "ingredients",
                newName: "ingridients");

            migrationBuilder.RenameIndex(
                name: "IX_ingredients_DishId",
                table: "ingridients",
                newName: "IX_ingridients_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ingridients",
                table: "ingridients",
                column: "Id");

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
