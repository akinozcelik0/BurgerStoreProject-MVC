using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalatiaBurger.DataAccess.Migrations
{
    public partial class shoppingCartEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExtraIngredientId",
                table: "ShoppingCarts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SideMealId",
                table: "ShoppingCarts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ExtraIngredientId",
                table: "ShoppingCarts",
                column: "ExtraIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_SideMealId",
                table: "ShoppingCarts",
                column: "SideMealId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_ExtraIngredients_ExtraIngredientId",
                table: "ShoppingCarts",
                column: "ExtraIngredientId",
                principalTable: "ExtraIngredients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_SideMeals_SideMealId",
                table: "ShoppingCarts",
                column: "SideMealId",
                principalTable: "SideMeals",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_ExtraIngredients_ExtraIngredientId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_SideMeals_SideMealId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_ExtraIngredientId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_SideMealId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ExtraIngredientId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "SideMealId",
                table: "ShoppingCarts");
        }
    }
}
