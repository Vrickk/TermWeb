using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TermWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Kudos = table.Column<int>(nullable: false),
                    Head = table.Column<string>(nullable: true),
                    IsStillGoing = table.Column<bool>(nullable: false),
                    WriterID = table.Column<string>(nullable: true),
                    MallName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PostDate = table.Column<DateTime>(nullable: false),
                    ViewNum = table.Column<int>(nullable: false),
                    DeliverPrice = table.Column<decimal>(nullable: false),
                    Etc = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    RemainDate = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
