using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autovermietung.Migrations
{
    public partial class changechedparameterinCarBillcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsBill_Bills_BillID",
                table: "CarsBill");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsBill_CarsBill_BillCarBillId",
                table: "CarsBill");

            migrationBuilder.DropIndex(
                name: "IX_CarsBill_BillCarBillId",
                table: "CarsBill");

            migrationBuilder.DropColumn(
                name: "BillCarBillId",
                table: "CarsBill");

            migrationBuilder.AlterColumn<int>(
                name: "BillID",
                table: "CarsBill",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsBill_Bills_BillID",
                table: "CarsBill",
                column: "BillID",
                principalTable: "Bills",
                principalColumn: "BillID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsBill_Bills_BillID",
                table: "CarsBill");

            migrationBuilder.AlterColumn<int>(
                name: "BillID",
                table: "CarsBill",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BillCarBillId",
                table: "CarsBill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarsBill_BillCarBillId",
                table: "CarsBill",
                column: "BillCarBillId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarsBill_Bills_BillID",
                table: "CarsBill",
                column: "BillID",
                principalTable: "Bills",
                principalColumn: "BillID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarsBill_CarsBill_BillCarBillId",
                table: "CarsBill",
                column: "BillCarBillId",
                principalTable: "CarsBill",
                principalColumn: "CarBillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
