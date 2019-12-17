using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class changetablesremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Company_CompanyId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_CompanyId",
                table: "Warehouse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_CompanyId",
                table: "Warehouse",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Company_CompanyId",
                table: "Warehouse",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
