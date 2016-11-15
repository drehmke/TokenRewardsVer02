using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TokenRewardsVer02.Data.Migrations
{
    public partial class initalSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LinkTitle = table.Column<string>(nullable: true),
                    LinkUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Unlocked = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    History = table.Column<string>(nullable: true),
                    HookText = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsPermanent = table.Column<bool>(nullable: false),
                    Limitations = table.Column<string>(nullable: true),
                    Mass = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Restrictions = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    UseSamples = table.Column<string>(nullable: true),
                    isPhysical = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                });

            migrationBuilder.AddColumn<string>(
                name: "SecondLife",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TokenTotal",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondLife",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TokenTotal",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Rewards");
        }
    }
}
