using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laptop.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandInLaptopObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Laptop_BrandId",
                table: "Laptop",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptop_Brand_BrandId",
                table: "Laptop",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptop_Brand_BrandId",
                table: "Laptop");

            migrationBuilder.DropIndex(
                name: "IX_Laptop_BrandId",
                table: "Laptop");
        }
    }
}
