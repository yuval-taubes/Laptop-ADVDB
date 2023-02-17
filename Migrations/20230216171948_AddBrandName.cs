using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laptop.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptop_Brand_BrandId",
                table: "Laptop");

            migrationBuilder.DropIndex(
                name: "IX_Laptop_BrandId",
                table: "Laptop");

            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "Laptop",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "Laptop");

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
    }
}
