using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourManagement.Migrations
{
    public partial class NewRegistrationServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistrationService",
                columns: table => new
                {
                    RegistrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationService", x => new { x.RegistrationId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_RegistrationService_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistrationService_TourRegistrations_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "TourRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEARAnM4p3ZYfQ7mDygufuiAaLGu8xJKSD4JECU/2K77bp7v0PO1Rb1EHUXlrvW7TMg==", "9e4ccad3-434c-440d-942e-d67da03e3eb6" });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationService_ServiceId",
                table: "RegistrationService",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationService");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEJrb4ZhqSAFwvz4mNs0TEehQ1sFLmp3Oznue6rbpDyJX+R84HGzu+LvTHxjgG+cq7A==", "070223d6-e133-4cf7-a576-de0316595509" });
        }
    }
}
