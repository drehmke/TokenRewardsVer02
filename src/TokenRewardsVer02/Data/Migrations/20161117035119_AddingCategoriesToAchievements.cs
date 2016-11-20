using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TokenRewardsVer02.Data.Migrations
{
    public partial class AddingCategoriesToAchievements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AchievementCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementCategories", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "AchievementCategoryId",
                table: "Achievements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_AchievementCategoryId",
                table: "Achievements",
                column: "AchievementCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_AchievementCategories_AchievementCategoryId",
                table: "Achievements",
                column: "AchievementCategoryId",
                principalTable: "AchievementCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_AchievementCategories_AchievementCategoryId",
                table: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_AchievementCategoryId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "AchievementCategoryId",
                table: "Achievements");

            migrationBuilder.DropTable(
                name: "AchievementCategories");
        }
    }
}
