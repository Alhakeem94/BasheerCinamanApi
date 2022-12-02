using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class ChangingProductNameToRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93Admin",
                column: "ConcurrencyStamp",
                value: "QX3XPFVDAUU9K6J66513");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93DataEntry",
                column: "ConcurrencyStamp",
                value: "FCTXTZT4C1DVA74ZOLJK");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93Dev",
                column: "ConcurrencyStamp",
                value: "9Y4WH1U2HDUXKC6KX2G3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "5ARJ968V5CJBEF5EBWJO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45d22d37-d284-410b-8024-82c0ae0a85b3", "AQAAAAEAACcQAAAAEJYOsWo2VYgWdt+oIfZUEO8ciFbXsKXeeY96OBcpZ/2uVsTExQJfxCh+EVn22mh1DQ==", "KK3ZHW5IFE5A2DGU80XI" });
        }
    }
}
