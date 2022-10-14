using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class SeedingDataBAseWithROles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "5ARJ968V5CJBEF5EBWJO");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a18be9c0-aa65-4af8-bd17-00bd93Admin", "QX3XPFVDAUU9K6J66513", "Admin", "ADMIN" },
                    { "a18be9c0-aa65-4af8-bd17-00bd93DataEntry", "FCTXTZT4C1DVA74ZOLJK", "DataEntry", "DATAENTRY" },
                    { "a18be9c0-aa65-4af8-bd17-00bd93Dev", "9Y4WH1U2HDUXKC6KX2G3", "Dev", "DEV" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45d22d37-d284-410b-8024-82c0ae0a85b3", "AQAAAAEAACcQAAAAEJYOsWo2VYgWdt+oIfZUEO8ciFbXsKXeeY96OBcpZ/2uVsTExQJfxCh+EVn22mh1DQ==", "KK3ZHW5IFE5A2DGU80XI" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93Admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93DataEntry");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd93Dev");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "2YB01GCL0BJV3WD00SLH");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d46f49e2-937e-45cf-84db-c40da17109b7", "AQAAAAEAACcQAAAAEBMXl55dR21dgKaTpt0ytfqisUBXJQ4IJI9aRxTZNLotB3tuTYT0nMCPox1YV61Z2g==", "SFQZOSN6ADZYTOZ72RD3" });
        }
    }
}
