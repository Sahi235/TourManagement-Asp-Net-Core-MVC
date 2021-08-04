using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourManagement.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Tours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "InitialPrice",
                table: "Tours",
                type: "Decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Till",
                table: "Tours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TourName",
                table: "Tours",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "TourRegistrations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEJrb4ZhqSAFwvz4mNs0TEehQ1sFLmp3Oznue6rbpDyJX+R84HGzu+LvTHxjgG+cq7A==", "070223d6-e133-4cf7-a576-de0316595509" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "InitialPrice",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Till",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "TourName",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "TourRegistrations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEKfjbbTZ7FpCw/0H+QlCGR3ZHOXtamrIy1zvaPErkcRFhTABwGRrisGLaZ5fjRgxLw==", "1a9a7669-e530-48aa-bd69-9ced217bf14b" });
        }
    }
}
