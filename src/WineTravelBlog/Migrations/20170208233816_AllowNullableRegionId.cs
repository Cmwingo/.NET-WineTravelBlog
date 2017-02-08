using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WineTravelBlog.Migrations
{
    public partial class AllowNullableRegionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Regions_RegionId",
                table: "Wines");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Wines",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Regions_RegionId",
                table: "Wines",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Regions_RegionId",
                table: "Wines");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Wines",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Regions_RegionId",
                table: "Wines",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
