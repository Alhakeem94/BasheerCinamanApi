using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class addingProvidorToProductBatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvidorId",
                table: "ProductBatchTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProvidorModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidorModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatchTable_ProvidorId",
                table: "ProductBatchTable",
                column: "ProvidorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBatchTable_ProvidorModel_ProvidorId",
                table: "ProductBatchTable",
                column: "ProvidorId",
                principalTable: "ProvidorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBatchTable_ProvidorModel_ProvidorId",
                table: "ProductBatchTable");

            migrationBuilder.DropTable(
                name: "ProvidorModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductBatchTable_ProvidorId",
                table: "ProductBatchTable");

            migrationBuilder.DropColumn(
                name: "ProvidorId",
                table: "ProductBatchTable");
        }
    }
}
