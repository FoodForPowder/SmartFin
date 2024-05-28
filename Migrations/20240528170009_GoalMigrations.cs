using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFin.Migrations
{
    /// <inheritdoc />
    public partial class GoalMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_userId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_userId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Recomendations_Users_userId",
                table: "Recomendations");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_userId",
                table: "Categories",
                column: "userId",
                principalTable: "Users",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_userId",
                table: "Expenses",
                column: "userId",
                principalTable: "Users",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendations_Users_userId",
                table: "Recomendations",
                column: "userId",
                principalTable: "Users",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_userId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_userId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Recomendations_Users_userId",
                table: "Recomendations");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_userId",
                table: "Categories",
                column: "userId",
                principalTable: "Users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_userId",
                table: "Expenses",
                column: "userId",
                principalTable: "Users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendations_Users_userId",
                table: "Recomendations",
                column: "userId",
                principalTable: "Users",
                principalColumn: "guid");
        }
    }
}
