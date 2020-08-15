using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class ShopSites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopSitesItem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    siteid = table.Column<int>(nullable: true),
                    price = table.Column<int>(nullable: false),
                    ShopSitesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopSitesItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShopSitesItem_Site_siteid",
                        column: x => x.siteid,
                        principalTable: "Site",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopSitesItem_siteid",
                table: "ShopSitesItem",
                column: "siteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopSitesItem");
        }
    }
}
