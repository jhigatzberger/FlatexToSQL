using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatexToSQL.Migrations
{
    public partial class ISIN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISIN",
                table: "Orders",
                type: "varchar(12)",
                maxLength: 12,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISIN",
                table: "Orders");
        }
    }
}
