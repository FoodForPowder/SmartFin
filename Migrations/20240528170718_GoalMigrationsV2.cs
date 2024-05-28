using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFin.Migrations
{
    /// <inheritdoc />
    public partial class GoalMigrationsV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "goalId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "goalId",
                table: "Users",
                type: "uuid",
                nullable: true);
        }
    }
}
