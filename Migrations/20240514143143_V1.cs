using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFin.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false),
                    income = table.Column<decimal>(type: "numeric", nullable: false),
                    goalId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    planSumm = table.Column<decimal>(type: "numeric", nullable: false),
                    factSumm = table.Column<decimal>(type: "numeric", nullable: false),
                    userId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.guid);
                    table.ForeignKey(
                        name: "FK_Categories_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    startOfPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    endOfPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    nameOfGoal = table.Column<string>(type: "text", nullable: false),
                    sum = table.Column<decimal>(type: "numeric", nullable: false),
                    payment = table.Column<decimal>(type: "numeric", nullable: false),
                    userId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.guid);
                    table.ForeignKey(
                        name: "FK_Goals_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    sum = table.Column<decimal>(type: "numeric", nullable: false),
                    dateOfExpense = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    categoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    userId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.guid);
                    table.ForeignKey(
                        name: "FK_Expenses_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recomendations",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    dateOfRecommendation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    goalId = table.Column<Guid>(type: "uuid", nullable: true),
                    userId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recomendations", x => x.guid);
                    table.ForeignKey(
                        name: "FK_Recomendations_Goals_goalId",
                        column: x => x.goalId,
                        principalTable: "Goals",
                        principalColumn: "guid");
                    table.ForeignKey(
                        name: "FK_Recomendations_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_userId",
                table: "Categories",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_categoryId",
                table: "Expenses",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_userId",
                table: "Expenses",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_userId",
                table: "Goals",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recomendations_goalId",
                table: "Recomendations",
                column: "goalId");

            migrationBuilder.CreateIndex(
                name: "IX_Recomendations_userId",
                table: "Recomendations",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Recomendations");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
