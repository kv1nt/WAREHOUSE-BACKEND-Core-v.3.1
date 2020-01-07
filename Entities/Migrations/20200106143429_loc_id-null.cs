using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class loc_idnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocationId",
                table: "Warehouse",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
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
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Warehouse",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
