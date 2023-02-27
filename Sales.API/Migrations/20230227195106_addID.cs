using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.API.Migrations
{
    /// <inheritdoc />
    public partial class addID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdCategories_Categories_CategoryId",
                table: "ProdCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProdCategories_ProdCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProdCategoryId_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProdCategories_CategoryId_Name",
                table: "ProdCategories");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProdCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ProdCategories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProdCategoryId_Name",
                table: "Products",
                columns: new[] { "ProdCategoryId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdCategories_CategoryId_Name",
                table: "ProdCategories",
                columns: new[] { "CategoryId", "Name" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdCategories_Categories_CategoryId",
                table: "ProdCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProdCategories_ProdCategoryId",
                table: "Products",
                column: "ProdCategoryId",
                principalTable: "ProdCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdCategories_Categories_CategoryId",
                table: "ProdCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProdCategories_ProdCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProdCategoryId_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProdCategories_CategoryId_Name",
                table: "ProdCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ProdCategoryId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ProdCategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProdCategoryId_Name",
                table: "Products",
                columns: new[] { "ProdCategoryId", "Name" },
                unique: true,
                filter: "[ProdCategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCategories_CategoryId_Name",
                table: "ProdCategories",
                columns: new[] { "CategoryId", "Name" },
                unique: true,
                filter: "[CategoryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdCategories_Categories_CategoryId",
                table: "ProdCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProdCategories_ProdCategoryId",
                table: "Products",
                column: "ProdCategoryId",
                principalTable: "ProdCategories",
                principalColumn: "Id");
        }
    }
}
