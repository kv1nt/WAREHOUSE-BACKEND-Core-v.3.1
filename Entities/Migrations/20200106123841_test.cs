using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Location_LocationId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Location_LocationId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Company_LocationId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Company");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Warehouse",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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
                name: "FK_Warehouse_Location_LocationId",
                table: "Warehouse");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Warehouse",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Company",
                nullable: true);

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
                name: "FK_Warehouse_Location_LocationId",
                table: "Warehouse",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
