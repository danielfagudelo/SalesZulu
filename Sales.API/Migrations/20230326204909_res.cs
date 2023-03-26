using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.API.Migrations
{
    /// <inheritdoc />
    public partial class res : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ProdCategoryId_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProdCategories_CategoryId_Name",
                table: "ProdCategories");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProdCategoryId",
                table: "Products",
                column: "ProdCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCategories_CategoryId",
                table: "ProdCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ProdCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProdCategories_CategoryId",
                table: "ProdCategories");

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
        }
    }
}
