using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class AddingShoppingReceiptTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerNotes",
                table: "ShoppingCartTable");

            migrationBuilder.CreateTable(
                name: "ShoppingRecieptTable",
                columns: table => new
                {
                    ShoppingCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfReciept = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecieptTotalAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingRecieptTable", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingRecieptTable_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93Admin",
                column: "ConcurrencyStamp",
                value: "GMDQ7IR7YRD48CLGJ7WY");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93DataEntry",
                column: "ConcurrencyStamp",
                value: "78H168IHFKNB3TY0FR64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93Dev",
                column: "ConcurrencyStamp",
                value: "HCUNHF9MTUBSLQCKT122");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "L98RUEWVVEA91PDK1NO3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6edd1642-66ef-440b-a1bb-0119ee5bb800", "AQAAAAEAACcQAAAAEAsAsU6DrLyOPSPyZFtn9SnSmpbQfF6oozjie91HDjB4g+HQhcgqgv/qfvzBYvTvYw==", "X8YXM4XB2P3H0329ZX6A" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTable_ShoppingCartId",
                table: "ShoppingCartTable",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingRecieptTable_UserId",
                table: "ShoppingRecieptTable",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartTable_ShoppingRecieptTable_ShoppingCartId",
                table: "ShoppingCartTable",
                column: "ShoppingCartId",
                principalTable: "ShoppingRecieptTable",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartTable_ShoppingRecieptTable_ShoppingCartId",
                table: "ShoppingCartTable");

            migrationBuilder.DropTable(
                name: "ShoppingRecieptTable");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartTable_ShoppingCartId",
                table: "ShoppingCartTable");

            migrationBuilder.AddColumn<string>(
                name: "CustomerNotes",
                table: "ShoppingCartTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93Admin",
                column: "ConcurrencyStamp",
                value: "78ICXGVZ6LQMFHDFHZTI");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93DataEntry",
                column: "ConcurrencyStamp",
                value: "5JLM2OUGDGKLQBVA4DQM");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93Dev",
                column: "ConcurrencyStamp",
                value: "CBHFKSJCLAUWLIMTJL04");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "8P30VW5Y4Q43MN30LZ7Z");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a6d7732-e52a-402a-aea3-463200744594", "AQAAAAEAACcQAAAAECVuVfIeDhsBAV+sGcxh4n9aLdrizmOV69Ms9KRq4vgLbZeViGBsSZ+O671MWZyGqA==", "LR3QR0P6XV3BCJXILO7S" });
        }
    }
}
