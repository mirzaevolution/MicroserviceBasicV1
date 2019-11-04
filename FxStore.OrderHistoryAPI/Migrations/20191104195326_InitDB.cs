using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FxStore.OrderHistoryAPI.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderHistories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    OrderCreated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderHistories");
        }
    }
}
