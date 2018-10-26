using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class addedseedvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelID", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "New York", "Plaza", "555-0123" },
                    { 2, "Paris", "Hotel Ritz", "555-0123" },
                    { 3, "London", "Claridges", "555-0123" },
                    { 4, "Singapore", "Raffles", "555-0123" },
                    { 5, "India", "Taj Mahal Palace", "555-0123" },
                    { 6, "Los Angeles", "Beverly Hills Hotel", "555-0123" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomID", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 0, "The Barrens Bedroom" },
                    { 2, 0, "The Tanaris Niche" },
                    { 3, 1, "The Ashenvale Forest Den" },
                    { 4, 1, "The Hinterlands Accommodation" },
                    { 5, 2, "The Badlands Cabin" },
                    { 6, 2, "The Stranglethorn Vale Cabin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 6);
        }
    }
}
