using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBasics.Migrations
{
    public partial class AddDummyDataToLanguagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Norwegian" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "English" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "Name" },
                values: new object[] { 3, "Swedish" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
