using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBasics.Migrations
{
    public partial class AddLanguageEntityAndManyToManyRelBetweenPersonAndLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LanguagePerson",
                columns: table => new
                {
                    LanguagesID = table.Column<int>(type: "int", nullable: false),
                    PeopleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagePerson", x => new { x.LanguagesID, x.PeopleID });
                    table.ForeignKey(
                        name: "FK_LanguagePerson_Languages_LanguagesID",
                        column: x => x.LanguagesID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguagePerson_People_PeopleID",
                        column: x => x.PeopleID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "Göteborg");

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePerson_PeopleID",
                table: "LanguagePerson",
                column: "PeopleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguagePerson");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "Stockholm");
        }
    }
}
