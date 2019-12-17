using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class delete_locId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Company_CompanyId",
                table: "Warehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Location_LocationId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_CompanyId",
                table: "Warehouse");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Warehouse",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Location_LocationId",
                table: "Warehouse",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Location_LocationId",
                table: "Warehouse");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Warehouse",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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
