using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking.Migrations
{
    public partial class FirstMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    SlotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<string>(nullable: false),
                    IsParked = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.SlotID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleNumber = table.Column<string>(maxLength: 10, nullable: false),
                    Company = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleNumber);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleNumber = table.Column<string>(nullable: true),
                    ParkingSlotsSlotID = table.Column<int>(nullable: true),
                    ParkedTime = table.Column<DateTime>(nullable: false),
                    UnparkedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parking_Slot_ParkingSlotsSlotID",
                        column: x => x.ParkingSlotsSlotID,
                        principalTable: "Slot",
                        principalColumn: "SlotID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parking_Vehicle_VehicleNumber",
                        column: x => x.VehicleNumber,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parking_ParkingSlotsSlotID",
                table: "Parking",
                column: "ParkingSlotsSlotID");

            migrationBuilder.CreateIndex(
                name: "IX_Parking_VehicleNumber",
                table: "Parking",
                column: "VehicleNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
