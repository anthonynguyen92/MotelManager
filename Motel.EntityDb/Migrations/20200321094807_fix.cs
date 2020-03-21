using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Motel.EntityDb.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogin",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogin", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserToken", x => x.UserId);
                });

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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Descriptions = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Dob = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    MotelRoomid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InforBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InforBills_MotelRooms_MotelRoomid",
                        column: x => x.MotelRoomid,
                        principalTable: "MotelRooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "IDuser", "Address", "Birthdate", "Email", "FirstName", "Identification", "LastName", "PhoneNumber", "Sex" },
                values: new object[] { new Guid("f1fad0e9-5a78-4987-b09a-6878d238f1a6"), "Ho Chi Minh", new DateTime(1998, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duongthuy111298@gmail.com", "Thuy", "183218131", "Duong Thi Thu", "0963902609", null });

            migrationBuilder.InsertData(
                table: "InforBills",
                columns: new[] { "Id", "ElectricBill", "MonthRent", "MotelRoomid", "ParkingFee", "RoomBil", "WaterBill", "WifiBill" },
                values: new object[] { new Guid("6c73a2ae-8116-406d-8710-5e1edb4b7b8b"), 1m, 1, null, 1m, 1m, 1m, 1m });

            migrationBuilder.InsertData(
                table: "MotelRooms",
                columns: new[] { "id", "Area", "BedRoom", "NameRoom", "Payment", "Status", "Toilet" },
                values: new object[] { new Guid("3dd6f0d0-f930-49da-8d7e-6d7fca1f0647"), 123, 1, "Anthony's Room", 12m, true, 1 });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "IdRent", "End", "FKCustomer", "FKMotel", "Start" },
                values: new object[] { new Guid("125e3fa2-e3fa-417c-9417-be7949c21c3d"), null, null, null, new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Local) });

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
                name: "AppRoleClaim");

            migrationBuilder.DropTable(
                name: "AppUserClaim");

            migrationBuilder.DropTable(
                name: "AppUserLogin");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserToken");

            migrationBuilder.DropTable(
                name: "InforBills");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MotelRooms");
        }
    }
}
