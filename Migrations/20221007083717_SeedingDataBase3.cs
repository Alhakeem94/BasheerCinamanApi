using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class SeedingDataBase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "QLL7ZEEHM8QJC93YKGDK");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e119c25-8e5d-40df-b88d-15a3e3d69d1e", "AQAAAAEAACcQAAAAEKQAXeexsEnKslQ2eP/BIVYOIQzocLhrZi0/PY7k8JpmAGW9ZMbuvsdpaEmrjeZIpw==", "J39R8984QOHZ751HH4AG" });
        }
    }
}
