using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TokenRewardsVer02.Data.Migrations
{
    public partial class AddingTokenValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondLife",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "TokenValue",
                table: "Achievements",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenValue",
                table: "Achievements");

            migrationBuilder.AddColumn<string>(
                name: "SecondLife",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
