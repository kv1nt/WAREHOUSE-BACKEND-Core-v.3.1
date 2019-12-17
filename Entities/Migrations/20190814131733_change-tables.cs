using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class changetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Location_LocationId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_LocationId",
                table: "Warehouse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_LocationId",
                table: "Warehouse",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Location_LocationId",
                table: "Warehouse",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
