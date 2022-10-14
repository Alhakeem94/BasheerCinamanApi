using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class AddingSeedingDataBase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "QKTQW6FNE0NEI9XZRBDQ");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c072942-f9dd-47f6-b793-69c651311df7", "AQAAAAEAACcQAAAAEBgFmY0nn/FVgpOcS0cNvUQSqYkDKZxCdi5W1aEY6eiEhSztaSb/cfcXYk+bcJx/YA==", "HO6VCQ5OFQFK3602GQQJ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
