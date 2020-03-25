using Microsoft.EntityFrameworkCore.Migrations;

namespace Motel.EntityDb.Migrations
{
    public partial class AddBillPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Payment",
                table: "InforBills",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payment",
                table: "InforBills");
        }
    }
}
