using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autovermietung.Migrations
{
    public partial class removedprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarID",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Bills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Bills",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
