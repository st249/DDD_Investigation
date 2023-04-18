using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD_Investigation.Migrations
{
    public partial class newsubclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VirtualOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PostCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirtualOrders_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VirtualOrders");
        }
    }
}
