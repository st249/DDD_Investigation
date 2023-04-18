using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD_Investigation.Migrations
{
    public partial class newsubclass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InPersonOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InPersonCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InPersonOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InPersonOrders_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InPersonOrders");
        }
    }
}
