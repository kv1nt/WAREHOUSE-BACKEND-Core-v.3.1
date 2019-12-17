using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class change_tables_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseId",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Company",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_CompanyId",
                table: "Warehouse",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_LocationId",
                table: "Warehouse",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_LocationId",
                table: "Company",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Location_LocationId",
                table: "Company",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Company_CompanyId",
                table: "Warehouse",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Location_LocationId",
                table: "Warehouse",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Location_LocationId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Company_CompanyId",
                table: "Warehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Location_LocationId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_CompanyId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_LocationId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Company_LocationId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Company");
        }
    }
}
