using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class addlocarionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Location_LocationId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_LocationId",
                table: "Warehouse");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Warehouse",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Warehouse",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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
