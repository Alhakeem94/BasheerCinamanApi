using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class addingProductBatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ProductsTable",
                newName: "TotalQuantityOfBatches");

            migrationBuilder.CreateTable(
                name: "ProductBatchTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatchQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBatchTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBatchTable_ProductsTable_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductsTable",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatchTable_ProductId",
                table: "ProductBatchTable",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductBatchTable");

            migrationBuilder.RenameColumn(
                name: "TotalQuantityOfBatches",
                table: "ProductsTable",
                newName: "Quantity");
        }
    }
}
