using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab6.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakeryProducts",
                columns: table => new
                {
                    BakeryProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakeryProducts", x => x.BakeryProductId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BakeryProductId = table.Column<int>(type: "int", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDamaged = table.Column<bool>(type: "bit", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_BakeryProducts_BakeryProductId",
                        column: x => x.BakeryProductId,
                        principalTable: "BakeryProducts",
                        principalColumn: "BakeryProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreadRecipes",
                columns: table => new
                {
                    BreadRecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    BakeryProductId = table.Column<int>(type: "int", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    IngredientName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    QuantityPerUnit = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreadRecipes", x => x.BreadRecipeId);
                    table.ForeignKey(
                        name: "FK_BreadRecipes_BakeryProducts_BakeryProductId",
                        column: x => x.BakeryProductId,
                        principalTable: "BakeryProducts",
                        principalColumn: "BakeryProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreadRecipes_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    SupplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.SupplyId);
                    table.ForeignKey(
                        name: "FK_Supplies_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreadRecipes_BakeryProductId",
                table: "BreadRecipes",
                column: "BakeryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BreadRecipes_IngredientId",
                table: "BreadRecipes",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BakeryProductId",
                table: "Orders",
                column: "BakeryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_IngredientId",
                table: "Supplies",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreadRecipes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "BakeryProducts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
