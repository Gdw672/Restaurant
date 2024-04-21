﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantTP.Migrations
{
    /// <inheritdoc />
    public partial class TestIngridietns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DishIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishIngredient_dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "dishes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredient_DishId",
                table: "DishIngredient",
                column: "DishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngredient");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "dishes");
        }
    }
}
