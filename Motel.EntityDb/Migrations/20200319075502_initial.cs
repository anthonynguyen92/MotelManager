using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Motel.EntityDb.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IDuser = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Identification = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Room = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IDuser);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Username);
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
                    Payment = table.Column<decimal>(nullable: false),
                    RoomRent = table.Column<int>(nullable: true)
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
                    IDRoom = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InforBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InforBills_MotelRooms_IDRoom",
                        column: x => x.IDRoom,
                        principalTable: "MotelRooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    IdRent = table.Column<string>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    MotelRoomid = table.Column<Guid>(nullable: true),
                    IDRoom = table.Column<Guid>(nullable: true),
                    IDuser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.IdRent);
                    table.ForeignKey(
                        name: "FK_Rents_Customers_IdRent",
                        column: x => x.IdRent,
                        principalTable: "Customers",
                        principalColumn: "IDuser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_MotelRooms_MotelRoomid",
                        column: x => x.MotelRoomid,
                        principalTable: "MotelRooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InforBills_IDRoom",
                table: "InforBills",
                column: "IDRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_MotelRoomid",
                table: "Rents",
                column: "MotelRoomid",
                unique: true,
                filter: "[MotelRoomid] IS NOT NULL");
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
