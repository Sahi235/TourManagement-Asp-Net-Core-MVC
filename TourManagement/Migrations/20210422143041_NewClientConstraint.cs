using Microsoft.EntityFrameworkCore.Migrations;

namespace TourManagement.Migrations
{
    public partial class NewClientConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEEEnophIqmiv/6BsHA9oZ+8JqHn+m5uEjWMxyD30IKlrDXTWLYrlzWSYfx/4goa7Jg==", "61e3d91a-f6be-4587-a5ed-e0dda9d47aef" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Name",
                table: "Clients",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Name",
                table: "Clients");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEFBVFTG+VazDYeDpqVh/Hon34Z2Vae6rjYQ4bFH/S8REC56iwoZpWT/kYEGs0jR4uQ==", "b4ad62b8-16d1-4fce-bb4c-daf729348fc6" });
        }
    }
}
