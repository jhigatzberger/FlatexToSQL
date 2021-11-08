using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatexToSQL.Migrations
{
    public partial class Stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISIN",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "FIGI",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    FIGI = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    ISIN = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
                    Ticker = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.FIGI);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.AlterColumn<string>(
                name: "FIGI",
                table: "Orders",
                type: "varchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISIN",
                table: "Orders",
                type: "varchar(12)",
                maxLength: 12,
                nullable: true);
        }
    }
}
