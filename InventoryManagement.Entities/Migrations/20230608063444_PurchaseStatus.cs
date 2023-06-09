using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Entities.Migrations
{
    public partial class PurchaseStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Purchases");
        }
    }
}
