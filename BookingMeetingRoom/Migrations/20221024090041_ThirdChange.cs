using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingMeetingRoom.Migrations
{
    public partial class ThirdChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayOfWeekMaster",
                columns: table => new
                {
                    DayOfWeekID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfWeek", x => x.DayOfWeekID);
                });

            migrationBuilder.CreateTable(
                name: "RoomAvailableBooking",
                columns: table => new
                {
                    RoomAvailableBookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    DayOfWeekID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAvailableBooking", x => x.RoomAvailableBookingID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e0ea44a-4439-4220-aa2d-97bf507f2d30", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05e8915c-7700-4f69-a88c-fc08b5053a00", null, "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayOfWeekMaster");

            migrationBuilder.DropTable(
                name: "RoomAvailableBooking");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05e8915c-7700-4f69-a88c-fc08b5053a00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e0ea44a-4439-4220-aa2d-97bf507f2d30");
        }
    }
}
