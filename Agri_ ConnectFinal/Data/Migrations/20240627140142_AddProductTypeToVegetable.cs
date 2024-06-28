using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agri__ConnectFinal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTypeToVegetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Vegetable",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Vegetable");
        }
    }
}
