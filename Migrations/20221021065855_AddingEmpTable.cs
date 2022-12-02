using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class AddingEmpTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpTable",
                columns: table => new
                {
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpTable");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93Admin",
                column: "ConcurrencyStamp",
                value: "KE5N8SOI27PRE5VBOVRH");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93DataEntry",
                column: "ConcurrencyStamp",
                value: "1KH5S8SZIY8SV5ZM799L");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93Dev",
                column: "ConcurrencyStamp",
                value: "5BVTRKIP0ZDNI4IHCVMG");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "EURH11Z4AD2LFXQP1SPQ");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9fdeea9b-21fb-40b8-b3fc-f62a86130b28", "AQAAAAEAACcQAAAAECx+3MxfvLCyEz2mOA3vAoeXsg/6nkGS/7IfFrJ7qkFx6yqypUrEZiCZgGe6Q4ZxZQ==", "BW6TUXPDMLE64YCRSPTV" });
        }
    }
}
