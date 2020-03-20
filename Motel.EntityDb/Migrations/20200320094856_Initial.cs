using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Motel.EntityDb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IDuser = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Identification = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IDuser);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MotelRooms",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    NameRoom = table.Column<string>(nullable: true),
                    BedRoom = table.Column<int>(nullable: false),
                    Toilet = table.Column<int>(nullable: false),
                    Area = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Payment = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotelRooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "InforBills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MonthRent = table.Column<int>(nullable: false),
                    WaterBill = table.Column<decimal>(nullable: false),
                    ElectricBill = table.Column<decimal>(nullable: false),
                    WifiBill = table.Column<decimal>(nullable: false),
                    ParkingFee = table.Column<decimal>(nullable: false),
                    RoomBil = table.Column<decimal>(nullable: false),
                    MotelRoomid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InforBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InforBills_MotelRooms_MotelRoomid",
                        column: x => x.MotelRoomid,
                        principalTable: "MotelRooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    IdRent = table.Column<Guid>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    FKMotel = table.Column<Guid>(nullable: true),
                    FKCustomer = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.IdRent);
                    table.ForeignKey(
                        name: "FK_Rents_Customers_FKCustomer",
                        column: x => x.FKCustomer,
                        principalTable: "Customers",
                        principalColumn: "IDuser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rents_MotelRooms_FKMotel",
                        column: x => x.FKMotel,
                        principalTable: "MotelRooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InforBills_MotelRoomid",
                table: "InforBills",
                column: "MotelRoomid");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_FKCustomer",
                table: "Rents",
                column: "FKCustomer",
                unique: true,
                filter: "[FKCustomer] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_FKMotel",
                table: "Rents",
                column: "FKMotel",
                unique: true,
                filter: "[FKMotel] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InforBills");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MotelRooms");
        }
    }
}
