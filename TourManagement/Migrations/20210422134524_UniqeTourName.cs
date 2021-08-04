using Microsoft.EntityFrameworkCore.Migrations;

namespace TourManagement.Migrations
{
    public partial class UniqeTourName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEFBVFTG+VazDYeDpqVh/Hon34Z2Vae6rjYQ4bFH/S8REC56iwoZpWT/kYEGs0jR4uQ==", "b4ad62b8-16d1-4fce-bb4c-daf729348fc6" });

            migrationBuilder.CreateIndex(
                name: "IX_Tours_TourName",
                table: "Tours",
                column: "TourName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tours_TourName",
                table: "Tours");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEARAnM4p3ZYfQ7mDygufuiAaLGu8xJKSD4JECU/2K77bp7v0PO1Rb1EHUXlrvW7TMg==", "9e4ccad3-434c-440d-942e-d67da03e3eb6" });
        }
    }
}
