using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBasics.Migrations
{
    public partial class AddDummyDataForCountriesCitiesAndPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Norway" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "USA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[] { 3, "Sweden" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CountryID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "New Asgard" },
                    { 2, 1, "Jotunheim" },
                    { 3, 2, "New York" },
                    { 4, 2, "Westview" },
                    //{ 5, 3, "Stockholm" },
                    { 5, 3, "Göteborg" },
                    { 6, 3, "Alingsås" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "CityID", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "Thor Odinson", "0123 456789" },
                    { 2, 1, "Valkyrie", "0123 456789" },
                    { 3, 1, "Sif", "7777 777777" },
                    { 4, 2, "Loki Odinson", "1234 567890" },
                    { 5, 2, "Sylvie Laufeysdottir", "0000 000000" },
                    { 6, 3, "Jane Foster", "2345 678901" },
                    { 7, 3, "Tony Stark", "9999 999999" },
                    { 8, 3, "Nick Fury", "8888 888888" },
                    { 9, 3, "Natasha Romanoff", "8888 888888" },
                    { 10, 4, "Darcy Lewis", "3456 789012" },
                    { 11, 4, "Wanda Maximoff", "5555 555555" },
                    { 12, 4, "Vision", "5555 555555" },
                    { 13, 5, "Erik Selvig", "4567 890123" },
                    { 14, 6, "Jenny Rigsjö", "0763 446373" }
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

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
