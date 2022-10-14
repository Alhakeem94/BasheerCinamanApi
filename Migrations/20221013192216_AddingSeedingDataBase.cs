using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class AddingSeedingDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "O5A91CFQRVUB5B0B6LZ0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa9ce76b-853d-4f89-927d-5b22e420375e", "AQAAAAEAACcQAAAAEMc0VmV97DezmG4Uan0RUZTxuiKoIAhJFK2VitlhrhBOzcahjB7qyX4KzPWscdny4A==", "BYK1694OGJZRSJ3SFPXJ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "GU3CFP0AOFJ1BXUMD1R4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef69059e-6a2d-47f3-bfed-4cd962a6629d", "AQAAAAEAACcQAAAAEOH32hY8kntatnPn9RhOoIaBeXkN/UabsDprjKnXw6tlcB34KZmW+sYmmUG95o4EaA==", "W5LXFDIWQ55ETTJZ9EMU" });
        }
    }
}
