using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class AddingProductsTableToDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProvidorsTable",
                newName: "ProvidorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductCompaniesTable",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductCatagoryTable",
                newName: "CatagoryId");

            migrationBuilder.CreateTable(
                name: "ProductsTable",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PriceOfPurchase = table.Column<double>(type: "float", nullable: false),
                    PriceOfSelling = table.Column<double>(type: "float", nullable: false),
                    PriceOfWholeSales = table.Column<double>(type: "float", nullable: false),
                    ProductImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatagoryId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsTable", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductsTable_ProductCatagoryTable_CatagoryId",
                        column: x => x.CatagoryId,
                        principalTable: "ProductCatagoryTable",
                        principalColumn: "CatagoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsTable_ProductCompaniesTable_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "ProductCompaniesTable",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTable_CatagoryId",
                table: "ProductsTable",
                column: "CatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTable_CompanyId",
                table: "ProductsTable",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsTable");

            migrationBuilder.RenameColumn(
                name: "ProvidorId",
                table: "ProvidorsTable",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "ProductCompaniesTable",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CatagoryId",
                table: "ProductCatagoryTable",
                newName: "Id");
        }
    }
}
