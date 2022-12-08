using Microsoft.EntityFrameworkCore.Migrations;

namespace TermWeb.Migrations
{
    public partial class ReleaseFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kudos",
                table: "Article");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kudos",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
