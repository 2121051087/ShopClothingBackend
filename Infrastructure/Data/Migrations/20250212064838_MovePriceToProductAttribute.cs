using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopClothing.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MovePriceToProductAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Xóa cột Price khỏi Product_Attributes
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product_Attributes");

            // Thêm cột Price vào Products
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Khôi phục cột Price vào Product_Attributes
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product_Attributes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            // Xóa cột Price khỏi Products
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");
        }
    }
}
