using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasheerCinamanApi.Migrations
{
    public partial class RemovingProfivorsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvidorsTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProvidorsTable",
                columns: table => new
                {
                    ProvidorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvidorAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidorsTable", x => x.ProvidorId);
                });
        }
    }
}
