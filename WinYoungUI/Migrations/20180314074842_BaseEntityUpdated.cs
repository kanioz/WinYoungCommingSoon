using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WinYoungUI.Migrations
{
    public partial class BaseEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NewsLetters");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedTime",
                table: "NewsLetters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedTime",
                table: "NewsLetters");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NewsLetters",
                nullable: false,
                defaultValue: false);
        }
    }
}
