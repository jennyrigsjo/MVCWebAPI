using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBasics.Migrations
{
    public partial class InsertDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "City", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "New Asgard", "Thor Odinson", "0123 456789" },
                    { 2, "Valhalla", "Loki Odinson", "1234 567890" },
                    { 3, "New York", "Jane Foster", "2345 678901" },
                    { 4, "New York", "Darcy Lewis", "3456 789012" },
                    //{ 5, "Stockholm", "Erik Selvig", "4567 890123" }
                    { 5, "Göteborg", "Erik Selvig", "4567 890123" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
