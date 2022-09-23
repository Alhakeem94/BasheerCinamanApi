using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class addingProvidorsTableToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBatchTable_ProvidorModel_ProvidorId",
                table: "ProductBatchTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProvidorModel",
                table: "ProvidorModel");

            migrationBuilder.RenameTable(
                name: "ProvidorModel",
                newName: "ProvidorsTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProvidorsTable",
                table: "ProvidorsTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBatchTable_ProvidorsTable_ProvidorId",
                table: "ProductBatchTable",
                column: "ProvidorId",
                principalTable: "ProvidorsTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBatchTable_ProvidorsTable_ProvidorId",
                table: "ProductBatchTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProvidorsTable",
                table: "ProvidorsTable");

            migrationBuilder.RenameTable(
                name: "ProvidorsTable",
                newName: "ProvidorModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProvidorModel",
                table: "ProvidorModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBatchTable_ProvidorModel_ProvidorId",
                table: "ProductBatchTable",
                column: "ProvidorId",
                principalTable: "ProvidorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
