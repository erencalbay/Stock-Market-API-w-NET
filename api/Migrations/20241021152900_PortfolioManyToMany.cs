using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class PortfolioManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Stock_StockId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c45b3dfa-bfe2-4c07-80d2-e004b130e135");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc2a142d-6e95-42a3-81f3-de48bde3128e");

            migrationBuilder.DropColumn(
                name: "Risk",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Stock",
                newName: "Stocks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    stockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => new { x.AppUserId, x.stockId });
                    table.ForeignKey(
                        name: "FK_Portfolios_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_Stocks_stockId",
                        column: x => x.stockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c4f9a77-1e30-4c34-9199-2b5f75b61af6", null, "Admin", "ADMIN" },
                    { "67c297f3-08b5-4968-9a83-ebf0c413c921", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_stockId",
                table: "Portfolios",
                column: "stockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Stocks_StockId",
                table: "Comments",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Stocks_StockId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c4f9a77-1e30-4c34-9199-2b5f75b61af6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67c297f3-08b5-4968-9a83-ebf0c413c921");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Stock");

            migrationBuilder.AddColumn<int>(
                name: "Risk",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c45b3dfa-bfe2-4c07-80d2-e004b130e135", null, "Admin", "ADMIN" },
                    { "dc2a142d-6e95-42a3-81f3-de48bde3128e", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Stock_StockId",
                table: "Comments",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id");
        }
    }
}
