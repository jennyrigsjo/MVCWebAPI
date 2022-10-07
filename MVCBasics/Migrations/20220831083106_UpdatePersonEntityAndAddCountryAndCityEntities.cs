using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBasics.Migrations
{
    public partial class UpdatePersonEntityAndAddCountryAndCityEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_CityID",
                table: "People",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityID",
                table: "People",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityID",
                table: "People");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_People_CityID",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
