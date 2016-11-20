using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TokenRewardsVer02.Data.Migrations
{
    public partial class TestingSomething : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatFilter",
                table: "Achievements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CatFilter",
                table: "Achievements",
                nullable: true);
        }
    }
}
