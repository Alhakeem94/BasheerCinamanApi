using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class AddingSeedingDataBase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "oi2eoij-1oqjsdkj-kaslk-OwnerRole", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "oi2eoij-1oqjsdkj-kaslk-OwnerRole", "QKTQW6FNE0NEI9XZRBDQ", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "9c072942-f9dd-47f6-b793-69c651311df7", "BasheerSuper@gmail.com", true, false, null, "BASHEERSUPER@GMAIL.COM", "BASHEERSUPER@GMAIL.COM", "AQAAAAEAACcQAAAAEBgFmY0nn/FVgpOcS0cNvUQSqYkDKZxCdi5W1aEY6eiEhSztaSb/cfcXYk+bcJx/YA==", null, false, "HO6VCQ5OFQFK3602GQQJ", false, "BasheerSuper@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "oi2eoij-1oqjsdkj-kaslk-OwnerRole", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });
        }
    }
}
