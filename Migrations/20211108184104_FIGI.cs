using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatexToSQL.Migrations
{
    public partial class FIGI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FIGI",
                table: "Orders",
                type: "varchar(12)",
                maxLength: 12,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FIGI",
                table: "Orders");
        }
    }
}
