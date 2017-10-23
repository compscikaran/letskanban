using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace letskanban.Migrations
{
    public partial class AddDateTimeToStories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Stories",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HoursRequired",
                table: "Stories",
                type: "int4",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "HoursRequired",
                table: "Stories");
        }
    }
}
